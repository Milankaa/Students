<template>
    <div id="StudentsOnCourse">
        <button class="back" @click="$router.go(-1)"> &#8678; </button>
        <h1>Studenti na kursu {{$route.params.title}}</h1>
        <p v-if="!allStudentsOnCourse.length">Nema studenata na ovom kursu!</p>
        <div v-bind:key="student.Student_id" v-for="student in allStudentsOnCourse">
            <div class="showSt">{{student.Ime}} {{student.Prezime}}</div>
        </div>
        <router-link  :to="{name: 'AddStudentsOnCourse', params:{id: $route.params.id, courseTitle:$route.params.title}}">Dodaj studente</router-link>
    </div>
</template>
<script>
    
    import { mapActions, mapGetters } from 'vuex';

    export default {
        name: 'StudentsOnCourse',
        methods: {
            ...mapActions(["getStudentsOnCourse"])
        },
        computed: mapGetters(["allStudentsOnCourse"]),
        created() {
            this.getStudentsOnCourse(this.$route.params.id);
        }
    };
     
</script>
<style scoped>
    .showSt {
        width: 100%;
        padding: 15px;
        margin: 5px 0 22px 0;
        display: inline-block;
        border: none;
        background-color:antiquewhite;
        text-align: left;
    }
</style>