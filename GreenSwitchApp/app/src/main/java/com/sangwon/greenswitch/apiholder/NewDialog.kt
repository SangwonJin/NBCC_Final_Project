package com.sangwon.greenswitch.apiholder

import android.R


import android.app.Dialog
import android.content.Context

import android.view.WindowManager
import androidx.annotation.LayoutRes

class NewDialog(
    context: Context
) : Dialog(context) {

    fun setWindowManager(gravity: Int, dimAmount: Float, transMode: Boolean) {
        WindowManager.LayoutParams().let {

            it.flags = WindowManager.LayoutParams.FLAG_DIM_BEHIND
            it.dimAmount = dimAmount
            it.gravity = gravity
            window?.attributes = it

            if (transMode)
                window?.setBackgroundDrawableResource(R.color.transparent)
        }
    }

    fun setWindowLayoutControl(height: Int, width: Int) {
        WindowManager.LayoutParams().let {
            val dp = context.resources.displayMetrics.density
            it.height = (height * dp).toInt()
            it.width = (width * dp).toInt()
            window?.setLayout(it.width,it.height)
        }
    }

}