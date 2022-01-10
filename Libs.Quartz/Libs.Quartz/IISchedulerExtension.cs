using Quartz;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Libs.Quartz
{
    public static class IISchedulerExtension
    {
        /// <summary>
        ///    Configura o worker (trigger com StartNow)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group">grupo do Worker (Contexto)</param>
        /// <param name="description">Descrição do worker, o que ele faz?</param>
        public static void Configure<T>(this IScheduler scheduler, string group, string description) where T : IJob
        {
            scheduler.ScheduleJob(CreateJob<T>(group, description),
                                  CreateTrigger());
        }
        /// <summary>
        ///    Configura Job com cron definida (
        ///    <a href="https://www.freeformatter.com/cron-expression-generator-quartz.html">criar cron</a> )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group">grupo do Job (Contexto)</param>
        /// <param name="description">Descrição da Job, o que ela faz?</param>
        /// <param name="cron">Perioticidade da execução, em formato Cron</param>
        /// 
        public static void Configure<T>(this IScheduler scheduler, string group, string description, string cron) where T : IJob
        {
            scheduler.ScheduleJob(CreateJob<T>(group, description),
                                  CreateTrigger(cron));
        }
        /// <summary>
        ///    Configura Job com cron definida ( 
        ///    <a href="https://www.freeformatter.com/cron-expression-generator-quartz.html">criar cron</a> )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="group">grupo do Job (Contexto)</param>
        /// <param name="description">Descrição da Job, o que ela faz?</param>
        /// <param name="crons">Perioticidades da execução, em formato Cron</param>
        public static void Configure<T>(this IScheduler scheduler, string group, string description, params string[] crons) where T : IJob
        {
            scheduler.ScheduleJob(CreateJob<T>(group, description),
                                  CreateTrigger(crons),
                                  false);
        }
        private static IJobDetail CreateJob<T>(string group, string description) where T : IJob
        {
            return JobBuilder.Create<T>()
                             .WithIdentity(typeof(T).GetTypeInfo().Name, group)
                             .WithDescription(description)
                             .RequestRecovery(true)
                             .StoreDurably()
                             .Build();
        }
        private static ITrigger CreateTrigger()
        {
            return TriggerBuilder.Create().StartNow().Build();
        }
        private static ITrigger CreateTrigger(string cron)
        {
            return TriggerBuilder.Create().WithCronSchedule(cron).Build();
        }
        private static IReadOnlyCollection<ITrigger> CreateTrigger(params string[] crons)
        {
            return new ReadOnlyCollection<ITrigger>(crons.Select(cron => TriggerBuilder.Create().WithCronSchedule(cron).Build()).ToList());
        }
    }
}
