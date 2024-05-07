
using System;
using System.Collections.Generic;
using System.Data;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareLocuitoriMemorie
    {
        //
        // Campuri & Proprietati auto-implemented
        //
        private List<Locuitor> locuitori;
        public int NrLocuitori
        {
            get { return locuitori.Count; }
        }

        private ReturnCodes operationReturnCode;

        //
        // constructoare
        //
        public AdministrareLocuitoriMemorie()
        {
            locuitori = new List<Locuitor>();
        }

        public AdministrareLocuitoriMemorie(List<Locuitor> DbLocuitori)
        {
            locuitori = DbLocuitori;
        }

        //
        // Metode
        //

        //
        // CRUD Operations
        //

        //Create
        public ReturnCodes AddLocuitor(Locuitor locuitor)
        {
            try
            {
                locuitori.Add(locuitor);
                return ReturnCodes.SUCCES;
            }
            catch (Exception) { return ReturnCodes.OPERATION_FAILED; }
        }

        // Read
        public ReturnCodes GetLocuitor(int id, out Locuitor locuitor)
        {
            locuitor = null;

            if (id < 1) return ReturnCodes.INVALID_INPUT_DATA;
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            foreach (Locuitor locuitorul in locuitori)
            {
                if (locuitorul.Id == id)
                {
                    locuitor = locuitorul;
                    return ReturnCodes.RECORD_EXISTS;
                }
            }
            return ReturnCodes.RECORD_DONT_EXISTS;
        }

        //public ReturnCodes CheckLocuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
        //{
        //    if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

        //    foreach (Locuitor locuitorul in locuitori)
        //    {
        //        if (locuitorul.Nume.Equals(nume) &&
        //            locuitorul.Prenume.Equals(prenume) && locuitorul.Sex.Equals(sex) &&
        //            locuitorul.DataNasterii.Equals(dataNasterii) && locuitorul.Cnp.Equals(cnp)
        //            && locuitorul.Camera == camera)
        //        {
        //            return ReturnCodes.RECORD_EXISTS;
        //        }
        //    }
        //    return ReturnCodes.RECORD_DONT_EXISTS;
        //}

        public ReturnCodes CheckLocuitor(string cnp)
        {
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            foreach (Locuitor locuitorul in locuitori)
            {
                if (locuitorul.Cnp.Equals(cnp)) return ReturnCodes.RECORD_EXISTS;
            }
            return ReturnCodes.RECORD_DONT_EXISTS;
        }

        public ReturnCodes GetAllLocuitori(out List<Locuitor> locuitori_)
        {
            locuitori_ = null;
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            locuitori_ = new List<Locuitor>(locuitori);
            return ReturnCodes.RECORD_EXISTS;
        }

        public ReturnCodes GetLocuitor(int id, out int index)
        {
            index = -1;

            if (id < 1) return ReturnCodes.INVALID_INPUT_DATA;
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            for (int i = 0; i < locuitori.Count; i++)
            {
                if (locuitori[i].Id == id)
                {
                    index = i;
                    return ReturnCodes.RECORD_EXISTS;
                }
            }

            return ReturnCodes.RECORD_DONT_EXISTS;
        }

        public ReturnCodes GetLastLocuitor(out Locuitor locuitor)
        {
            locuitor = null;

            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            locuitor = locuitori[NrLocuitori - 1];

            return ReturnCodes.RECORD_EXISTS;
        }

        // Update
        public ReturnCodes UpdateLocuitor(int id, string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
        {
            if (id < 1) return ReturnCodes.INVALID_INPUT_DATA;
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            operationReturnCode = GetLocuitor(id, out int index);

            if (operationReturnCode == ReturnCodes.RECORD_EXISTS)
            {
                locuitori[index].Nume = nume;
                locuitori[index].Prenume = prenume;
                locuitori[index].Sex = sex;
                locuitori[index].DataNasterii = dataNasterii;
                locuitori[index].Cnp = cnp;
                locuitori[index].Camera = camera;

                return ReturnCodes.SUCCES;
            }

            return ReturnCodes.RECORD_DONT_EXISTS;
        }

        // Delete
        public ReturnCodes DeleteLocuitor(int id)
        {
            if (id < 1) return ReturnCodes.INVALID_INPUT_DATA;
            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            operationReturnCode = GetLocuitor(id, out int index);

            if (operationReturnCode == ReturnCodes.RECORD_EXISTS)
            {
                locuitori.RemoveAt(index);
                return ReturnCodes.SUCCES;
            }
            else return operationReturnCode;
        }

        public ReturnCodes ListToDataTableConverter(out DataTable locuitori_)
        {
            locuitori_ = new DataTable();

            if (locuitori.Count == 0) return ReturnCodes.RECORD_DONT_EXISTS;

            try
            {
                locuitori_.Columns.Add(new DataColumn("ID", typeof(int)));
                locuitori_.Columns.Add(new DataColumn("Nume", typeof(string)));
                locuitori_.Columns.Add(new DataColumn("Prenume", typeof(string)));
                locuitori_.Columns.Add(new DataColumn("Sex", typeof(Sexe)));
                locuitori_.Columns.Add(new DataColumn("Data nasterii", typeof(DateTime)));
                locuitori_.Columns.Add(new DataColumn("CNP", typeof(string)));
                locuitori_.Columns.Add(new DataColumn("Camera", typeof(int)));

                foreach (Locuitor locuitor in locuitori)
                {
                    locuitori_.Rows.Add(locuitor.Id, locuitor.Nume, locuitor.Prenume, locuitor.Sex, locuitor.DataNasterii, locuitor.Cnp, locuitor.Camera);
                }

                return ReturnCodes.SUCCES;
            }
            catch (Exception) { return ReturnCodes.OPERATION_FAILED; }
        }
    }
}
