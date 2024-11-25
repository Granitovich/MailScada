using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CourseProject.BLL.Models;

namespace CourseProject.BLL.Interfaces
{
    public interface ISensorService
    {
        Task<Guid> CreateSensor(SensorMailModel model);
        Task<List<SensorMailModel>> GetSensors();
        Task DeleteSensor(Guid id);
        Task UpdateSensorValue(UpdateMailModel model);
    }
}
