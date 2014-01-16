/*
 * Copyright (c) 2013 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
 * in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License
 * is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions and limitations under
 * the License.
 */

/**
 * This file contains the Backbone models that are used to represent different
 * objects in the web app.
 */

/**
 * Representation of the customer and their associated data.
 * This object stores all data associated with the user including
 * maskedWalletResponse and fullWalletResponse.
 */
var bikeStore = bikeStore || {};

(function(models) {

  /**
  * Model representing user information.
  * @type {Backbone.Model}
  */
  models.User = Backbone.Model.extend({
  defaults: {
    loggedIn: false,
    email: null,
    shortEmail: null,
    maskedWallet: null,
    fullWallet: null
    }
  });

  /**
   * Model representing purchaseable items.
   * @type {Backbone.Model}
   */
  models.Item = Backbone.Model.extend({
    defaults: {
      id: '',
      name: 'Bike',
      unitPrice: 0,
      totalPrice: 0,
      quantity: 0,
      description: 'Description.',
      image: '/Images/wallet.jpg'
    },
    initialize: function() {
    }
  });

  /**
  * Representation of the currently selected item.
  * This is binded with ItemInfoView
  * @type {Backbone.Model}
  */
  models.CurrentItem = Backbone.Model.extend({
    defaults: {
      defined: false,
      item: new models.Item()
    },
    initialize: function() {
      _.bindAll(this, 'setItem');
    },
    setItem: function(currItem) {
      if (currItem)
        {
        this.set({
          defined: true,
          item: currItem
        });
      bikeStore.Cookie.setCurrentItem(currItem);
      }
    }
  });

  /**
   * Collection of purchaseable items.
   * @type {Backbone.Collection}
   */
  models.Items = Backbone.Collection.extend({
    model: models.Item
  });

  /**
   * Collection of items in the shopping cart.
   * @type {Backbone.Collection}
   */
  models.Cart = Backbone.Collection.extend({
    model: models.Item
  });
})(window.bikeStore.Models = window.bikeStore.Models || {});
