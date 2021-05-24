package com.sangwon.greenswitch

import android.util.Log
import com.google.gson.GsonBuilder
import com.google.gson.JsonArray
import com.sangwon.greenswitch.apiholder.MenuList
import com.sangwon.greenswitch.apiholder.MenuListItem
import okhttp3.OkHttpClient
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.*


object Api {

    private const val BASE_URL= "http://10.0.2.2:44355/api/"
    //http 로깅 생성
    private val interceptor = HttpLoggingInterceptor(
        object :HttpLoggingInterceptor.Logger{
            override fun log(message: String) {
                Log.d("ApiLog:", message)
            }
        }).apply {
        level = HttpLoggingInterceptor.Level.BODY
    }
    private val client: OkHttpClient = OkHttpClient.Builder()
        .retryOnConnectionFailure(true)
        .addInterceptor(interceptor).build()
    //레트로핏 생성
    val gson = GsonBuilder().setLenient().create()
    val api: ApiSo = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .client(client)
        .addConverterFactory(GsonConverterFactory.create(gson))
        .build()
        .create(ApiSo::class.java)
}


interface ApiSo {

    //getEmployee input: Employee id
    @GET("employee/jin/{id}")
    suspend fun getEmployeeIdList(
        @Path("id") id: String
    ): GetEmployApiItem

    //DepartmentId
   @GET("/department/all/{departmentId}")
    suspend fun filterDepartmentId(
       @Path("departmentId") departmentId: String
    ):GetEmployApi

    //AllDepartment
   @GET("employee/department/all")
    suspend fun allDepartmentList():List<GetEmployApiItem>

//   @GET("department")
//   suspend fun departmentMenuList(): MenuList
   @GET("department")
   suspend fun departmentMenuList(): MenuList
}