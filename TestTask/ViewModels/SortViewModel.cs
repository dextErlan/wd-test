using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestTask.ViewModels
{
    public class SortViewModel
    {
        public SortState NumberSort { get; private set; } // значение для сортировки по номеру
        public SortState OrgSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NumberSort = sortOrder == SortState.NumberAsc ? SortState.NumberDesc : SortState.NumberAsc;
            OrgSort = sortOrder == SortState.OrgAsc ? SortState.OrgDesc : SortState.OrgAsc;
            Current = sortOrder;
        }    
}
}
