/*
*	<copyright file="Address.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>lufer</author>
*   <date>10/18/2020 6:07:02 PM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializeTo
{
    /// <summary>
    /// Purpose:
    /// Created by: lufer
    /// Created on: 10/18/2020 6:07:02 PM
    /// </summary>
    /// <remarks>Auxiliar</remarks>
    /// <example>Address aux = new Address();</example>
    public class Address
    {
        #region Attributes
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode = "99999";
        
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Address()
        {

            this.Street = "4627 Sunset Ave"; this.City = "San Diego"; this.State = "CA"; this.PostalCode = "92115";
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
        ~Address()
        {
        }
        #endregion

        #endregion
    }
}
