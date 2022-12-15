using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Query;
using Standard.Tool.Platform.Data.Entities;
using Standard.Tool.Platform.Materials.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Materials
{
    public class EditMaterialRequest
    {
        public EditMaterialRequest(IEnumerable<Material> materialDataList) 
        {
            MaterialDataList = materialDataList;
        }

        public IEnumerable<Material> MaterialDataList { get; private set; }


        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CreateMaterialValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
