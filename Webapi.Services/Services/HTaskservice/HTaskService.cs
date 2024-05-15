using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Data.Entities;
using Webapi.Services.Models;
using AppContext = Webapi.Data.Migrations.AppContext;

namespace Webapi.Services.Services.HTaskservice
{
    public class HTaskService : IHTaskService
    {
        private readonly AppContext _context;
        private readonly IMapper _mapper;





        public TaskDto AddTask(TaskDto taskDto)
        {
            var task = _mapper.Map<HTask>(taskDto);
            _context.HTasks.Add(task);
            _context.SaveChanges();
            return _mapper.Map<TaskDto>(task);
        }


        public bool DeleteTaskById(int id)
        {
            var taskToDelete = _context.HTasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete == null)
            {
                return false;
            }

            _context.HTasks.Remove(taskToDelete);
            _context.SaveChanges();
            return true;
        }

        public List<TaskDto> GetAllTasks()
        {
            var tasks = _context.HTasks.ToList();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public TaskDto GetTaskById(int id)
        {
            var task = _context.HTasks.FirstOrDefault(t => t.Id == id);
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto UpdateTask(int id, TaskDto taskDto)
        {
            var taskToUpdate = _context.HTasks.FirstOrDefault(t => t.Id == id);
            if (taskToUpdate == null)
            {
                return null;
            }

            _mapper.Map(taskDto, taskToUpdate);
            _context.SaveChanges();

            return _mapper.Map<TaskDto>(taskToUpdate);

        }
        
    }
}

