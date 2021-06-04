using eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.DataAccess
{
    public class EFPhotoDal : EFEntityRepositoryBase<Photo, MeerschaumContext>, IPhotosDal
    {
    }
}
