﻿using BuzzOff_Pre_Alpha.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Model
{
    internal class SolicitationModel
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idDenunciation"></param>
        /// <param name="priority"></param>
        /// <param name="description"></param>
        public SolicitationModel(int idDenunciation, MyEnuns.Priority priority, string description)
        {            
            IdDenunciation = idDenunciation;
            Priority = priority;
            Description = description;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idDenunciation"></param>
        /// <param name="priority"></param>
        /// <param name="description"></param>
        public SolicitationModel(int id, int idDenunciation, MyEnuns.Priority priority, string description)
        {
            Id = id;
            IdDenunciation = idDenunciation;
            Priority = priority;
            Description = description;
        }

        public int Id { get; set; }
        public int IdDenunciation { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public string Description { get; set; }
    }
}
