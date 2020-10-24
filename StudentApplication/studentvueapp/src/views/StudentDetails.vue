<template>
    <div id="StudentDetail" class="container">
        <button class="back" @click="$router.go(-1)"> &#8678; </button>
        <h2>Detalji o studentu</h2>
        <table>
            <tr>
                <th>Ime </th>
                <td>{{model.Ime}} {{model.Prezime}}</td>
            </tr>
            <tr>
                <th>Broj Indeksa</th>
                <td>{{model.BrojIndeksa}}</td>
            </tr>
            <tr>
                <th>Godina</th>
                <td>{{model.Godina}}</td>
            </tr>
            <tr>
                <th>Status Studenta</th>
                <td>{{status(model.StatusStudenta)}}</td>
            </tr>
            <tr>
            <td class="subtitle" align="center" colspan="2"> Kursevi koje pohađa </td>
            </tr>
            <tr v-if="!model.Kurs.length"> 
            <td align="center" colspan="2">Student ne pohađa nijedan kurs!</td>
            </tr>
            <tr v-bind:key="course.ID_kursa" v-for="course in model.Kurs">
                <td colspan="2">{{course.NazivKursa}}</td>
            </tr>
        </table>
        </div>
    </template>
<script>
    import {  mapActions, mapState } from 'vuex';
   
    export default {
        name: 'StudentDetails',
        data() {
            return {
                ID_kursa:1
            }
        },
        methods: {
            ...mapActions(["getStudent"]),
            status(statusID) {
                if (statusID == 1)
                    return "Redovan";
                return "Vanredan";
            }
        },
        computed: {
           ...mapState({
                model: (state) => state.Student.model
           })
        },
        created() {
            if (this.$route.params.id) {
                this.getStudent(this.$route.params.id);
            }
        }
       
    };
</script>
<style>
    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
        width: 100%;
        font-size:26px;
    }

    td, th {
        border: none;
        text-align: left;
        padding: 8px;
    }
    th{
        width:30%
            
    }

    .subtitle{
        width:100%;
        background-color:beige;
        font-size:24px;
        font-weight:bold;
        text-align:center;
    }
</style>
