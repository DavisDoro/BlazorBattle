using BlazorBattle.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattle.Client.Services
{
    public class UnitService : IUnitService

    {
        private readonly HttpClient _http;
        public UnitService(HttpClient http)
        {
            _http = http;
        }
        public IList<Unit> Units { get; set; } = new List<Unit>();

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();



        //IList<Unit> IUnitService.Units { get; set; }

        public void AddUnit(int unitId)
        {
            var unit = Units.First(unit => unit.Id == unitId);
            MyUnits.Add(new UserUnit { UnitId = unitId, HitPoints = unit.HitPoints });

            //Console.WriteLine($"{unit.Title} was built!");
            //Console.WriteLine($"Your army size: {MyUnits.Count}");
        }

        public async Task LoadUnitsAsync()
        {
            if (Units.Count == 0)
            {
                Units = await _http.GetFromJsonAsync<IList<Unit>>("api/Unit");

            }
        }
    }
}
