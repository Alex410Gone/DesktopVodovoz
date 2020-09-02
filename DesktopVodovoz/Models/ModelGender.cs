using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVodovoz.Models
{
    public partial class ModelGender
    {
        public string Value { get; set; }
        public string Name { get; set; }

        public static List<ModelGender> GetGenders()
        {
            List<ModelGender> genders = new List<ModelGender>
            {
                new ModelGender() { Value = "Мужской", Name = "Сударь" },
                new ModelGender() { Value = "Женский", Name = "Сударыня" }
            };

            return genders;
        }
    }
}
