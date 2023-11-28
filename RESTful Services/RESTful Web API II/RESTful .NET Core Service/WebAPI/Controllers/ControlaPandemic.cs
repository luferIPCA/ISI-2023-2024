/*
*	<copyright file="ControlaPandemic.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>lufer</author>
*   <date>5/15/2020 12:19:25 PM</date>
*	<description></description>
**/
using WebAPI.Models;
//using WebAPI.View;

namespace WebAPI.Controller
{

    public interface IIndicadoresControl
    {
        
        //controlar Model
        void SetModel(IIndicadoresModel m);
        void MoreDeads(int v);
        void MoreInfected(int v);
        void MoreRecovered(int v);
        //void tLessInfected(int v);

        int Mortes();
        int Recuperados();
        int Infetados();

        //controlar View
        //void SetView(IIndicadoresView v);
        //void RequestMoreDeads(int v);
        //void RequestMoreInfected(int v);
        //void RequestMoreRecovered(int v);
        //void RequestLessInfected(int v);

    }
    /// <summary>
    /// Purpose:
    /// Created by: lufer
    /// Created on: 12/12/2020
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ControlaPandemic : IIndicadoresControl
    {
        private IIndicadoresModel ind;
        //private IIndicadoresView indView;
        

        //construtor
        #region Construtors
        //public ControlaPandemic(IIndicadoresModel m, IIndicadoresView v)
        //{
        //    ind = m;
        //    indView = v;
        //}
        public ControlaPandemic(IIndicadoresModel m)
        {
            ind = m; 
        }       
        public ControlaPandemic()
        {
            ind = new Indicadores();
            //indView = new IndicadoresView(this);

            //indView.QuantasMortes();
            //indView.QuantosInfetados();
            //indView.QuantosRecuperados();

            //indView.ShowAll();
        }

        #endregion

        #region Control_Model

        #region Indicadores
        public void SetModel(IIndicadoresModel m)
        {
            this.ind = m;
        }
        public void MoreDeads(int v)
        {
            if (ind != null)
            {
                ind.Mortes += v;
            }
        }

        public void MoreInfected(int v)
        {
            if (ind != null)
            {
                ind.Infetados += v;
            }
        }
        public void MoreRecovered(int v)
        {
            if (ind != null)
            {
                ind.Recuperados += v;
            }
        }

        public int Mortes()
        {
            return ind.Mortes;
        }

        public int Infetados()
        {
            return ind.Infetados;
        }

        public int Recuperados()
        {
            return ind.Recuperados;
        }
        #endregion

        #endregion

        #region Control_View

        //public void SetView(IIndicadoresView v)
        //{
        //    this.indView = v;
        //}
        //public void RequestMoreDeads(int v)
        //{
        //    if (indView != null)
        //    {
        //        indView.QuantasMortes();
        //    }
        //}

        //public void RequestMoreInfected(int v)
        //{
        //    if (indView != null)
        //    {
        //        indView.QuantosInfetados();
        //    }
        //}

        //public void RequestMoreRecovered(int v)
        //{
        //    if (indView != null)
        //    {
        //        indView.QuantosRecuperados();
        //    }
        //}
        #endregion

    }
}
