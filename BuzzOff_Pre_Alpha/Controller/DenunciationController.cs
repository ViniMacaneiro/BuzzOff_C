using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class DenunciationController
    {
        private DenunciationDAO DAO;

        public DenunciationController()
        {
            DAO = new DenunciationDAO();
        }

        public void Insert(DenunciationModel model)
        {
            DAO.Insert(model);
        }

        public void Update(DenunciationModel model)
        {
            DAO.Update(model);
        }

        public DenunciationModel GetOne (int id)
        {
            return DAO.GetOne(id);
        }
        public List<DenunciationModel> GetByInformer(int id)
        {
            return DAO.GetByInformerId(id);
        }
        public List<DenunciationModel> GetByInformerIdAndIsAnswered(int id, bool b)
        {
            return DAO.GetByInformerIdAndIsAnswered(id, b);
        }

        public List<DenunciationModel> GetAll()
        {
            return DAO.GetAll();
        }

        public void Delete(int id)
        {
            DAO.Delete(id);
        }
        public void Delete2()
        {
            DAO.Delete2();
        }
    }
}
