import Vue from 'vue';
import App from './App.vue';
import store from './store';
import router from './router'
import { domain, clientId } from "../auth_config.json";
import { Auth0Plugin } from "./auth";
import VueSimpleAlert from "vue-simple-alert";

Vue.use(Auth0Plugin, {
    domain,
    clientId,
    onRedirectCallback: appState => {
        router.push(
            appState && appState.targetUrl
                ? appState.targetUrl
                : window.location.pathname
        );
    }
});
Vue.use(VueSimpleAlert);

Vue.config.productionTip = false


new Vue({
    store,
    router,
    render: h => h(App)
}).$mount('#app')
