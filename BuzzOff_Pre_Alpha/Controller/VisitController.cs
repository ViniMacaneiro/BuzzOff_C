using BuzzOff_Pre_Alpha.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzOff_Pre_Alpha.Model;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class VisitController
    {
        private readonly VisitDAO DAO;

        public VisitController()
        {
            DAO = new VisitDAO();
        }

        public void CreateVisit(VisitModel model)
        {
            DAO.Insert(model);
        }

        public void UpdateVisit(VisitModel model)
        {
            DAO.Update(model);
        }

        public VisitModel GetVisit(int id)
        {
            return DAO.GetOne(id);
        }

        public List<VisitModel> GetAllVisits()
        {
            return DAO.GetAll();
        }

        public void DeleteVisit(int id)
        {
            DAO.Delete(id);
        }
    }
}

