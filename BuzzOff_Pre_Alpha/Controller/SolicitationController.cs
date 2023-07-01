using BuzzOff_Pre_Alpha.Model;

using BuzzOff_Pre_Alpha.Repository.DAO;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class SolicitationController
    {
        private SolicitationDAO solicitationDAO;

        public SolicitationController()
        {
            solicitationDAO = new SolicitationDAO();
        }

        public void CreateSolicitation(SolicitationModel model)
        {            
            solicitationDAO.Insert(model);
        }

        public void UpdateSolicitation(SolicitationModel model)
        {           
            solicitationDAO.Update(model);
        }

        public SolicitationModel GetSolicitation(int id)
        {
            return solicitationDAO.GetOne(id);
        }

        public List<SolicitationModel> GetAllSolicitations()
        {
            return solicitationDAO.GetAll();
        }

        public void DeleteSolicitation(int id)
        {
            solicitationDAO.Delete(id);
        }

    }
}
