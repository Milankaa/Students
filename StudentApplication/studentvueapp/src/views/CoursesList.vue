<template>
    <div id="CoursesList">
        <button class="back" @click="$router.go(-1)"> &#8678; </button>
        <h1>Svi kursevi</h1>
        <ol>
            <li v-bind:key="course.ID_kursa" v-for="course in allCourses">
                <router-link :to="{name:'StudentsOnCourse', params:{id: course.ID_kursa, title:course.NazivKursa}}">{{course.NazivKursa }} {{course.ID_kursa}}</router-link>
            </li>
        </ol>
    </div>
</template>
<script>
    import { mapGetters, mapActions } from 'vuex';
   

    export default {
        name: 'CourseList',
        data() {
            return {
                course_id: 1,
            }
        },

        methods: {
            ...mapActions(["getCourses", "getStudentOnCourse"])
            
        },
        computed: mapGetters(["allCourses"]),
        created() {
            this.getCourses();
        }
    };
</script>
<style scoped>
  
    a {
        width: 100%;
        padding: 15px;
        margin: 5px 0 22px 0;
        display: inline-block;
        border: none;
        background: #f1f1f1;
        text-align: left;
        cursor: pointer;
    }
</style>