/*
*	<copyright file="Indicador.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>lufer</author>
*   <date>15/12/2020 </date>
*	<description></description>
**/

using System;

namespace WebAPI.Models
{

    public interface IIndicadoresModel
    {
        int Recuperados { get; set; }
        int Mortes { get; set; }
        int Infetados { get; set; }

        string Date { get; set; }

        void AddInfected(int v);
    }



    [Serializable]
    /// <summary>
    /// Purpose:
    /// Created by: lufer
    /// Created on: 12/12/2020
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Indicador : IIndicadoresModel
    {
        private int totInfetados;
        private int totMortes;
        private int totRecuperados;
        private string d;

        //Properties em modo Lambda Expressions
        //public int Inf { get => totInfetados; set => totInfetados = value; }
        //public int Mor { get => totMortes; set => totMortes = value; }
        //public int Rec { get => totRecuperados; set => totRecuperados = value; }
        public string Date { get => d; set => d = value; }
        
        public Indicador()
        {
            totInfetados = 0;
            totMortes = 0;
            totRecuperados = 0;
            d = DateTime.Today.ToString();
        }

        #region Metodos
        public int Infetados
        {
            set { totInfetados += value; d = DateTime.Now.ToString(); }
            get { return totInfetados; }
        }

        public int Recuperados
        {
            set { totRecuperados += value; d = DateTime.Now.ToString(); }
            get { return totRecuperados; }
        }

        public int Mortes
        {
            set { totMortes += value; d = DateTime.Now.ToString(); }
            get { return totMortes; }
        }

        public void AddInfected(int v)
        {
            if (v > 0)
            {
                totInfetados += v;
                d = DateTime.Now.ToString();
            }
        }

        #endregion
    }
}
