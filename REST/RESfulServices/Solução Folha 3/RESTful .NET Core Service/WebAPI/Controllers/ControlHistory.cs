/*
*	<copyright file="ControlHistory.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>lufer</author>
*   <date>5/21/2020 10:34:15 AM</date>
*	<description></description>
**/

using WebAPI.Models;
//using MVC_II.View;

namespace WebAPI.Controller
{
    /// <summary>
    /// Purpose:
    /// Created by: lufer
    /// Created on: 5/21/2020 10:34:15 AM
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ControlHistory
    {
        #region Attributes
        private IIndicadoresHistory indHist;

        #endregion

        #region Control_Model

        #region IndicadoresHistory

        public void SetModel(IIndicadoresHistory m)
        {
            this.indHist = m;
        }

        public void NewIndicator(Indicadores i)
        {
            if (indHist != null)
            {
                //testar de não existe
                indHist.AddIndicador(i);
            }
        }

        public bool SaveHistory(string s)
        {
            if (indHist != null)
            {
                return indHist.SaveHistory(s);
            }
            return false;
        }

        public bool LoadHistory(string s)
        {
            if (indHist != null)
            {
                return indHist.LoadHistory(s);
            }
            return false;
        }

        #endregion

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ControlHistory()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ControlHistory()
        {
        }
        #endregion

        #endregion
    }
}
