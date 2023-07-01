using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class DengueFocusController
    {
        private DengueFocusDAO dengueFocusDAO;

        public DengueFocusController()
        {
            dengueFocusDAO = new DengueFocusDAO();
        }

        public void InsertDengueFocus(DengueFocusModel model)
        {
            dengueFocusDAO.Insert(model);
        }

        public void UpdateDengueFocus(DengueFocusModel model)
        {
            dengueFocusDAO.Update(model);
        }

        public DengueFocusModel GetDengueFocus(int id)
        {
            return dengueFocusDAO.GetOne(id);
        }

        public List<DengueFocusModel> GetAllDengueFocus()
        {
            return dengueFocusDAO.GetAll();
        }

        public void DeleteDengueFocus(int id)
        {
            dengueFocusDAO.Delete(id);
        }
    }
}
