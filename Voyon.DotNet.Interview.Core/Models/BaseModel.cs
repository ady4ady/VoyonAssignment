using System;

namespace Voyon.DotNet.Interview.Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseModel))
                return false;

            BaseModel model = (BaseModel)obj;
            return Id == model.Id;
        }
    }
}