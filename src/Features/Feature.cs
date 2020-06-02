using System;

namespace feature_flags.Features {
    public interface IFeature {
        string Name {get;set;}
        string Description {get;set;}
    }

    public class Feature : IFeature
    {
        public string Name {get;set;}
        public string Description {get;set;}

        public static IFeature Create(string name, string descrption) {
            return new Feature() {
                Name = name,
                Description = descrption
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Feature feature &&
                   Name == feature.Name &&
                   Description == feature.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description);
        }

        public static bool operator ==(Feature a, Feature b) {
            return string.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool operator !=(Feature a, Feature b) {
            return !string.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}