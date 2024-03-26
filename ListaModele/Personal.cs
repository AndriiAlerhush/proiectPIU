
using System;

namespace ListaModele
{
    public class Personal : Persoana
    {
        // post
        private string post;
        public string Post
        {
            get { return post; }
            set
            {
                if (value != "portar" && value != "persoana de serviciu" && value != "administrator")
                {
                    post = "inexistent";
                }
                else { post = value; }
            }
        }

        // constructoare

        public Personal() : base()
        {
            Post = "-";
        }

        public Personal(string nume, string prenume, string sex, string post) : base(nume, prenume, sex)
        {
            Post= post;
        }

        public Personal(string nume, string prenume, string sex, DateTime dataNasterii, string cnp, string post) : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Post = post;
        }

        public Personal(Personal personal) : base(personal)
        {
            if (personal != null && this != personal)
            {
                Post = personal.Post;
            }
        }

        // metode

        public override string ToString()
        {
            return string.Format("Nume:          {0}\n" +
                                 "Prenume:       {1}\n" +
                                 "Sex:           {2}\n" +
                                 "Data nasterii: {3}\n" +
                                 "Varsta:        {4}\n" +
                                 "CNP:           {5}\n" +
                                 "ID:            {6}\n" +
                                 "Post:          {7}\n",
                                 Nume, Prenume, Sex, DataNasterii.ToShortDateString(), Varsta, CNP, Id, post);
        }


    }
}
