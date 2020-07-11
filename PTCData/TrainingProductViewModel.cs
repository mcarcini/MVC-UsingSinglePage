﻿using System.Collections.Generic;

namespace PTCData
{
  public class TrainingProductViewModel
  {
    public TrainingProductViewModel()
    {
      // Initialize blank list
      Products = new List<TrainingProduct>();
      SearchEntity = new TrainingProduct();
      EventCommand = "List";
    }

    public List<TrainingProduct> Products { get; set; }
    public TrainingProduct SearchEntity { get; set; }
    public string EventCommand { get; set; }

    public void HandleRequest()
    {
      switch (EventCommand.ToLower())
      {
        case "list":
        case "search":
          Get();
          break;

        case "resetsearch":
          ResetSearch();
          Get();
          break;
      }
    }

    private void ResetSearch()
    {
      SearchEntity = new TrainingProduct();
    }

    private void Get()
    {
      TrainingProductManager mgr = new TrainingProductManager();

      Products = mgr.Get(SearchEntity);
    }
  }
}
