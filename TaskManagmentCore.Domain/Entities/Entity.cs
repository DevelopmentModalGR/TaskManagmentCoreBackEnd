using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManagementCore.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            //Id = Guid.NewGuid().ToString("N").ToUpper();
        }

        //public string Id { get; private set; }

        public int Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}

