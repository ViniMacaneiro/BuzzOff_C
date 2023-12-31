﻿using BuzzOff_Pre_Alpha.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Model
{
    internal class DengueFocusModel
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocusModel(int idAddress, int IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {            
            this.IdAddress = idAddress;
            this.IdVisit = IdVisit;
            this.Type = type;
            this.IsEradicated = false;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocusModel(int id, int idAddress, int IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {
            this.Id = id;
            this.IdAddress = idAddress;
            this.IdVisit = IdVisit;
            this.Type = type;
            this.IsEradicated = isEradicated;
        }

        public int Id { get; set; }
        public int IdAddress { get; set; }
        public int IdVisit { get; set; }
        public MyEnuns.FocusType Type { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public bool IsEradicated { get; set; }
    }
}
