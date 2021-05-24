package com.sangwon.greenswitch

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.item_main.view.*

class MainAdapter(var dataList: List<GetEmployApiItem> = listOf(), val clickEvent: (Int) -> Unit) :
    RecyclerView.Adapter<MainAdapter.ViewHolder>() {

    inner class ViewHolder(v: View) : RecyclerView.ViewHolder(v) {

        init {
            v.setOnClickListener {
                clickEvent(absoluteAdapterPosition)
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int) =
        ViewHolder(
            LayoutInflater.from(parent.context)
                .inflate(R.layout.item_main, parent, false)
        )

    override fun getItemCount(): Int = dataList.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val data = dataList[position]
        holder.itemView.also {
            it.tv_lastName2.text = " "+data.LastName
            it.tv_name2.text = " "+ data.FirstName
            it.tv_officeNumber2.text = " "+ data.WorkPhone
            it.tv_officeLocation2.text = " "+ data.StreetAddress
            it.tv_officePosition2.text = " "+ data.getTypeString()


            data.MiddleInitial ?: return
            it.tv_middleName2.text = data.MiddleInitial
        }

    }

}

fun GetEmployApiItem.getTypeString(): String {
    return when (this.Type) {
        0 -> "HrSupervisor"
        1 -> "RegularSupervisor"
        2 -> "HrEmployee"
        3 -> "RegularEmployee"
        else -> ""
    }
}