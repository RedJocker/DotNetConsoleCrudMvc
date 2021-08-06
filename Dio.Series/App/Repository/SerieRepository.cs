using System;
using System.Collections.Generic;
using System.Linq;
using Dio.Series.App.Model;

namespace Dio.Series.App.Repository
{
    public class SerieRepository
    {
        public Dictionary<int, Serie> repository = new();

        public void Add(Serie serie) {
            repository.Add(serie.GetId(), serie);
        }

        public List<Serie> GetAll() {
            return repository.Values.ToList();
        }

        public Serie GetOne(int id) {
            return repository[id];
        }

        public void Update(Serie entity) {
            repository[entity.GetId()] = entity;
        }

        public bool Contains(int id) {
            return repository.ContainsKey(id);
        }

        internal void Remove(int id)
        {
            repository.Remove(id);
        }
    }
}