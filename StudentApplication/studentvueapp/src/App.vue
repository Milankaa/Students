<template>
  <div id="app">
    <NavBar/>
    <router-view/>
  </div>
</template>
<script>
    import NavBar from './views/NavBar.vue'

    export default {
        components: {
            NavBar
        }
    };
</script>
<style>
#app {
  font-family: 'Arial Unicode MS';
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
    .back {
        font-size: 40px;
        float: left;
        background-color: grey;
        cursor: pointer;
        padding: 0px 10px;
    }
    button, input[type=reset] {
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        cursor: pointer;
        border-radius: 12px;
        opacity: 0.9;
        background-color:forestgreen;
    }
    button [type=submit] {
        background-color: #4CAF50;
    }

</style>
