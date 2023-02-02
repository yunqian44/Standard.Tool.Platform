using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Tool.Platform.Auth.PermissionFeature.Validations
{

    public class UpdateAccountPermissionValidation : AccountPermissionValidation<EditAccountPermissionRequest>
    {
        public UpdateAccountPermissionValidation()
        {
            ValidateCollectionCount();
        }
    }
}
