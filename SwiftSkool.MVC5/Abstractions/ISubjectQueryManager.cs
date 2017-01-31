﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Abstractions
{
    public interface ISubjectQueryManager
    {
        Task<List<SimpleSubjectViewModel>> GetSubjects();
        Task<List<SubjectViewModel>> GetSubjectsByClass(string classname);
    }
}