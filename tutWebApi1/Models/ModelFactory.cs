﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using tutWepApi1.Repository.Entities;

namespace tutWebApi1.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public FoodModel Create(Food food)
        {
            return new FoodModel()
            {
                Url = _urlHelper.Link("Food", new { foodid = food.Id }),
                Description = food.Description,
                Measures = food.Measures.Select(x => Create(x))
            };
        }

        internal MeasureV2Model Create2(Measure measure)
        {
            return new MeasureV2Model()
            {
                Url = _urlHelper.Link("Measures", new { foodid = measure.food_id, id = measure.Id }),
                Description = measure.Description,
                Calories = measure.Calories,
                Carbonhydrates = measure.Carbonhydrates,
                Fiber = measure.Fiber,
                Protien = measure.Protien,
                Sugar = measure.Sugar
            };
        }

        public MeasureModel Create(Measure measure)
        {
            return new MeasureModel()
            {
                Url = _urlHelper.Link("Measures", new { foodid = measure.food_id, id = measure.Id }),
                Description = measure.Description,
                Calories = measure.Calories
            };
        }

        public DiarySummaryModel CreateSummary(Diary diary)
        {
            return new DiarySummaryModel()
            {
                DiaryDate = diary.CurrentDate,
                TotalCalories = 10
            };
        }

        public DiaryEntryModel Create(DiaryEntry diaryEntry)
        {
            return new DiaryEntryModel()
            {
                Url = _urlHelper.Link("DiaryEntries", new { diaryid = diaryEntry.DiaryCurrentDate, id = diaryEntry.Id }),
                Id = diaryEntry.Id,
                diary_id = diaryEntry.diary_id
            };
        }

        public DiaryModel Create(Diary x)
        {
            return new DiaryModel()
            {
                Url = _urlHelper.Link("Diaries", new { diaryid = x.CurrentDate.ToString("yyyy-MM-dd") }),
                CurrentDate = x.CurrentDate
            };
        }

        public AuthTokenModel Create(AuthToken authToken)
        {
            return new AuthTokenModel()
            {
                Token = authToken.Token,
                Expiration = authToken.Expiration
            };
        }
    }
}
