<template>

    <div id="NavBar">
        <ul>
            <li><router-link :to="{name:'Home'}" class="navbar-item">Home</router-link></li>
            <li v-if="$auth.isAuthenticated"><router-link :to="{name:'StudentList'}" class="navbar-item">Lista studenata</router-link></li>
            <li v-if="$auth.isAuthenticated"><router-link :to="{name: 'NewStudent'}" class="navbar-item">Novi student</router-link></li>
            <li v-if="$auth.isAuthenticated"><router-link :to="{name: 'DeleteStudent'}" class="navbar-item">Brisanje studenata</router-link></li>
            <li><router-link :to="{name: 'ListOfCourses'}" class="navbar-item">Lista kurseva</router-link></li>
            <li v-if="$auth.isAuthenticated"><router-link :to="{name: 'NewCourse'}" class="navbar-item">Novi kurs</router-link></li>
            <li class="login" v-if="!$auth.loading">
               <a v-if="!$auth.isAuthenticated" @click="login" ><strong>Prijavite se</strong></a>
               <a v-if="$auth.isAuthenticated" @click="logout" ><strong>Odjavite se</strong></a>
            </li>
        </ul>
    </div>
</template>
<script>
   
    export default {
        name: 'NavBar',
        methods: {
            login() {
                this.$auth.loginWithRedirect();
            },
            logout() {
                this.$auth.logout({
                    returnTo: window.location.origin
                });
            }
        }

    }
</script>
<style scoped>
    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        overflow: hidden;
        background-color: #333;
    }

    li {
        float: left;
    }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

         li a:hover {
                background-color:dimgrey;
         }
         .login{
                float:right;
         }
    @media screen and (max-width: 600px) {
        ul li, ul li.login {
            float: none;
        }
    }
</style>