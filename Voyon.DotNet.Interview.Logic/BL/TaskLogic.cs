using Voyon.DotNet.Interview.Core.Models;
using Voyon.DotNet.Interview.Core.Repositories;
using Voyon.DotNet.Interview.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Voyon.DotNet.Interview.Logic.BL
{
    public class TaskLogic : ITaskLogic
    {
        private readonly ITaskRepository _tasksRepository;
        private readonly IUserRepository _usersRepository;

        public TaskLogic(ITaskRepository tasksRepository, IUserRepository usersRepository)
        {
            _tasksRepository = tasksRepository;
            _usersRepository = usersRepository;
        }

        public bool Add(TaskViewModel task)
        {
            try
            {
                if (!string.IsNullOrEmpty(task.Id))
                {
                    return _tasksRepository.Create(new Task
                    {
                        Id = new Guid(task.Id),
                        Title = task.Title,
                        Description = task.Description,
                        IsFinished = task.IsFinished,
                        AssignedUserId = new Guid(task.AssignedUser.Id)
                    });
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id, TaskViewModel task)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return _tasksRepository.Delete(new Guid(id), new Task
                    {
                        Id = new Guid(task.Id)
                    });
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(string id, TaskViewModel task)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var assignId = task.AssignedUser == null ? "7997404d-8991-4eec-83c7-d4794e23921a" : task?.AssignedUser?.Id;
                    return _tasksRepository.Update(new Guid(id), new Task
                    {
                        Id = new Guid(task.Id),
                        Title = task.Title,
                        Description = task.Description,
                        IsFinished = task.IsFinished,
                        AssignedUserId = new Guid(assignId)
                        // AssignedUserId = new Guid(task.AssignedUser.Id)
                    });
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaskViewModel Get(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var taskModel = _tasksRepository.Get(new Guid(id));

                    return new TaskViewModel
                    {
                        Id = taskModel.Id.ToString(),
                        Title = taskModel.Title,
                        Description = taskModel.Description,
                        IsFinished = taskModel.IsFinished,
                        AssignedUser = new UserViewModel
                        {
                            Id = taskModel.AssignedUserId.ToString(),
                            Username = _usersRepository.Get(taskModel.AssignedUserId).Username
                        }
                    };
                }
                else
                {
                    return new TaskViewModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TaskViewModel> Get()
        {
            try
            {
                var tasks = _tasksRepository.Get();
                return tasks.Select(t => new TaskViewModel
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    IsFinished = t.IsFinished,
                    AssignedUser = new UserViewModel
                    {
                        Id = t.AssignedUserId.ToString(),
                        Username = _usersRepository.Get(t.AssignedUserId).Username
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
