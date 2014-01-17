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
 * This file contains all global variables.
 */
// Page transition type.
var transitionType;
// Product image path.
var imgSrc;
// Screen sizes.
var windowHeight = window.innerHeight ||
  document.documentElement.clientHeight || document.body.clientHeight;
var WIDTH_515 = 515;
var WIDTH_495 = 495;
var WIDTH_460 = 460;
var WIDTH_360 = 360;
var WIDTH_320 = 320;
// Width of screen.
var windowWidth = window.innerWidth ||
  document.documentElement.clientWidth || document.body.clientWidth;
transitionType = (windowWidth <= WIDTH_515) ? 'slide' : 'none';
if (windowWidth <= WIDTH_320) {
  imgSrc = "/Images/products/320";
} else if(windowWidth <= WIDTH_460) {
  imgSrc = "/Images/products/460";
} else if (windowWidth <= WIDTH_495){
  imgSrc = "/Images/products/495";
} else {
  imgSrc = "/Images/products/default";
}
