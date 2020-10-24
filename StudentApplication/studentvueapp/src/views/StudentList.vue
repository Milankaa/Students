<template>
    <div id="StudentList">
        <form>
            <button class="back" @click="$router.go(-1)"> &#8678; </button>
            <h1>Svi studenti</h1>
            <p v-if="!allStudents.length">Nema studenata za prikaz!</p>
            <table>
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th></th>
                </tr>
                <tr v-if="!allStudents.length">
                    <td colspan="3"> Nema studenata! </td>
                </tr>
                <tr v-bind:key="student.Student_id" v-for="student in allStudents">
                    <td>{{student.Ime }}</td>
                    <td>{{student.Prezime}}</td>
                    <td>
                        <ul>
                            <li><button type="submit" class="del" v-on:click="delStudent(student.Student_id)">Obriši</button></li>
                            <li><router-link :to="{name:'UpdateStudent', params:{id: student.Student_id}}" class="newStudent">Izmjeni</router-link></li>
                            <li><router-link :to="{name:'StudentDetails', params:{id: student.Student_id}}" class="newStudent">Detalji</router-link></li>
                        </ul>
                    </td>
                </tr>
            </table>
            <br />
            <router-link :to="{name:'NewStudent'}" class="newStudent">Novi Student</router-link>
        </form>
    </div>
</template>

<script>

    import { mapGetters, mapActions } from 'vuex';
   
    export default {
        name: 'StudentList',
        data() {
            return {
                Student_id: 1
            }
        },
        
        methods: {
            ...mapActions(['getStudents', "deleteStudent"]),
            delStudent(id) {
                if (confirm("Da li ste sigurni da želite obrisati studenta?")) {
                    this.deleteStudent(id);
                    this.getStudents();
                    this.$alert("Uspješno ste obrisali studenta!");
                }
            },
            
        },
        computed: mapGetters(["allStudents"]),
        created() {
            this.getStudents();
        }
    };
</script>

<style scoped>
    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
        width: 100%;
    }

    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
        width: 33%;
    }

    
    
    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        overflow: hidden;
    }

    li {
        float: left;
    }

        li button {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

            li button:hover:not(.active) {
                background-color: #111;
            }
    .newStudent {
        background-color: #008CBA;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        border-radius: 12px;
        margin: 8px 0px;
    }
    .del {
        padding: 15px 32px;
        text-align: center;
        background-color: red;
        color: black;
        font-size: 16px;
        font-weight:bold;
        
    }
</style>