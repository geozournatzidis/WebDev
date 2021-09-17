using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace EntityBondGadgeCollectiont.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Appears in this movie")]
        public string AppearsIn { get; set; }

        [Required]
        [DisplayName("Leading actor")]
        public string WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = -1;
            Name = "";
            Description = "";
            AppearsIn = "";
            WithThisActor = "";
        }

        public GadgetModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }

    }
}