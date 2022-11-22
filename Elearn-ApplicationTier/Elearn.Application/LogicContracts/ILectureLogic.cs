﻿using Elearn.Shared.Dtos;
using Elearn.Shared.Models;

namespace Elearn.Application.LogicInterfaces;

public interface ILectureLogic
{
    Task<Lecture> CreateAsync(Lecture lecture);
    Task<List<Lecture>> GetAllLecturesAsync();
    Task<Lecture?> GetLectureAsync(string url);
}