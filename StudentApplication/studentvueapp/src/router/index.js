import Vue from 'vue'
import VueRouter from 'vue-router'


Vue.use(VueRouter)

  const routes = [
      {
          path: '/',
          name: 'Home',
          component: () => import('../views/Home.vue')
      },
     {
          path: '/StudentList',
          name: 'StudentList',
          component: () => import('../views/StudentList.vue')
      },
      {
          path: '/CreateStudent',
          name: 'NewStudent',
          component: ()  => import('../views/CreateStudent.vue')
      },
      {
          path: '/DeleteStudent',
          name: 'DeleteStudent',
          component: ()  => import('../views/DeleteStudent.vue')
      },
      {
          path: '/CoursesList',
          name: 'ListOfCourses',
          component: () => import('../views/CoursesList.vue')
      },
      {
          path: '/NewCourse',
          name: 'NewCourse',
          component: ()  => import('../views/NewCourse.vue')
      },
      {
          path: '/StudentDetails/:id',
          name: 'StudentDetails',
          component: () => import('../views/StudentDetails.vue')
      },
      {
          path: '/UpdateStudent/:id',
          name: 'UpdateStudent',
          component: () => import('../views/CreateStudent.vue')
      },
      {
          path: '/Course/:id/StudentsOnCourse',
          name: 'StudentsOnCourse',
          component: () => import('../views/StudentsOnCourse.vue')
      },
      {
          path: '/Course/:id/AddStudentsOnCourse',
          name: 'AddStudentsOnCourse',
          component: () => import('../views/AddStudentsOnCourse.vue')
      }
]

const router = new VueRouter({
  routes
})

export default router
