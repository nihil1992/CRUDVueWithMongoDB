import { createApp } from 'vue'
import App from './App.vue'

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import Axios from 'axios';
import Vuex from 'vuex';
import 'es6-promise/auto';


createApp(App).mount('#app')
createApp.use(Vuex)

//createApp.config.productionTip = false;