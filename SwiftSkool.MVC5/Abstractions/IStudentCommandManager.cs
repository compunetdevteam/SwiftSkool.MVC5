﻿using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface IStudentCommandManager
    {
        Task RegisterStudent(CreateStudentViewModel model);
    }
}