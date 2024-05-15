using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Services.Models;

namespace Webapi.Services.Services.HTaskservice
{
    public interface IHTaskService
    {
        List<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        TaskDto AddTask(TaskDto taskDto);
        TaskDto UpdateTask(int id, TaskDto taskDto);
        bool DeleteTaskById(int id);
    }
}
