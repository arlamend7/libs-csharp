using NHibernate;

namespace Libs.Nhibernate.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Iniciar uma transação no banco de dados
        /// </summary>
        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        /// <summary>
        /// Desfazer as alterações realizadas em uma transação
        /// </summary>
        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Rollback();
        }

        /// <summary>
        /// Aplicar as alterações realizadas em uma transação
        /// </summary>
        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Commit();
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }

            if (session.IsOpen)
            {
                session.Close();
            }
            session = null;
        }

        public void Clear()
        {
            if (session != null)
                session.Clear();
        }

        public void FlushSessao()
        {
            if (session != null)
                session.Flush();
        }
    }
}
