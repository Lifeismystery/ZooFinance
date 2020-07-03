using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Validation;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZooFinances.Model;

namespace ZooFinances.Preserver
{
    public class LogbookPresenter : Form
    {
        private Finances _view;
        private LogbookModel _model;

        public LogbookPresenter(Finances view, LogbookModel model)
        {
            _view = view;
            _model = model;

            _view.presenter = this;
        }

        public void Run()
        {
            _view.Show();
        }

        #region LoadData

        public void LoadData()
        {
            _model.AnimalTypeTable.Load();
            _model.FoodPriceTable.Load();
            _model.AnimalsTable.Load();
            _view.animalTypeTableBindingSource.DataSource = _model.AnimalTypeTable.ToList();
            _view.foodPriceTableBindingSource.DataSource = _model.FoodPriceTable.ToList();
            _view.animalsTableBindingSource.DataSource = _model.AnimalsTable.ToList();
        }

        #endregion

        #region InsertData

        public void InsertData()
        {
            _view.animalsTableBindingSource.AddNew();
            _model.SaveChanges();
        }

        #endregion

        #region UpdateData

        public void UpdateData()
        {
            try
            {
                _view.animalsTableBindingSource.EndEdit();
                _view.animalsTableBindingSource.ResetBindings(false);
                _view.animalsTableBindingSource.EndEdit();
                _model.SaveChanges();
                _view.animalsTableBindingSource.ResetBindings(false);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        #endregion

        #region DeleteData

        public void DeleteData()
        {
            if (MessageBox.Show("Delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _view.animalsTableBindingSource.RemoveCurrent();
            }
        }

        #endregion

        #region Spending

        public int GetAnimalByType(string animalType)
        {
            return _model.AnimalsTable.AsEnumerable().Where(p => p.Animal_Type.Contains(animalType)).Count();
        }

        public double GetFoodPrice(string animalType)
        {
            string foodType = GetFoodPTypeByAnimalType(animalType);
            return (double)_model.FoodPriceTable.AsEnumerable().Where(p => p.Food_Type.Contains(foodType)).Select(p => p.Food_Price).FirstOrDefault();
        }

        public string GetFoodPTypeByAnimalType(string animalType)
        {
            return _model.AnimalTypeTable.AsEnumerable().Where(p => p.Animal_Type.Contains(animalType)).Select(p => p.Food_Type).FirstOrDefault();
        }

        public double GetFoodRatePerDay(string animalType)
        {
            return _model.AnimalTypeTable.AsEnumerable().Where(p => p.Animal_Type.Contains(animalType)).Select(p => p.Food_Rate_Per_Day).FirstOrDefault();        
        }

        public double Spending()
        {
            double price = 0.0;
            foreach (var animalType in _model.AnimalsTable.AsEnumerable().SelectMany(p => p.AnimalTypeTable.Animal_Type))
            {
                price += GetAnimalByType(animalType.ToString()) * GetFoodPrice(animalType.ToString()) * GetFoodRatePerDay(animalType.ToString());
            }
            return price;
        }

        #endregion
    }
}
