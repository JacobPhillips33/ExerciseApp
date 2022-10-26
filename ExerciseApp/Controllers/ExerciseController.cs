﻿using ExerciseApp.Models;
using ExerciseApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IActionResult Index()
        {
            var exerciseList = _exerciseRepository.AllExercisesList();

            return View(exerciseList);
        }
        #region Views OrderedBy Ascending and Descending by Column
        public IActionResult ViewByIDDesc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderByDescending(x => x.ExerciseID).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByNameDesc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderByDescending(x => x.Name).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByBodyPartAsc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderBy(x => x.BodyPart).ToList();  
            return View(sortedList);
        }
        public IActionResult ViewByBodyPartDesc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderByDescending(x => x.BodyPart).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByTargetMuscleAsc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderBy(x => x.TargetMuscle).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByTargetMuscleDesc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderByDescending(x => x.TargetMuscle).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByEquipmentAsc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderBy(x => x.Equipment).ToList();
            return View(sortedList);
        }
        public IActionResult ViewByEquipmentDesc()
        {
            var sortedList = _exerciseRepository.AllExercisesList().OrderByDescending(x => x.Equipment).ToList();
            return View(sortedList);
        }
        #endregion Views OrderedBy Ascending and Descending by Column
        public IActionResult ViewExercise(int id)
        {
            var exercise = _exerciseRepository.SpecificExercise(id);

            return View(exercise);
        }
        public IActionResult ViewSelectByProperty()
        {
            var exercise = _exerciseRepository.AssignProperties();

            return View(exercise);
        }

        public IActionResult ViewBodyPartExerciseList(Exercise exercise)
        {
            var exerciseList = _exerciseRepository.ExercisesByBodyPart(exercise);

            return View(exerciseList);
            
        }
        public IActionResult ViewTargetMuscleExerciseList(Exercise exercise)
        {
            var exerciseList = _exerciseRepository.ExercisesByTargetMuscle(exercise);

            return View(exerciseList);
        }
        public IActionResult ViewEquipmentExerciseList(Exercise exercise)
        {
            var exerciseList = _exerciseRepository.ExercisesByEquipmentNeeded(exercise);

            return View(exerciseList);
        }
    }
}
