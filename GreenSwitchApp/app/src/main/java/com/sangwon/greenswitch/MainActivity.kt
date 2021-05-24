package com.sangwon.greenswitch


import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Spinner
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.sangwon.greenswitch.apiholder.MenuListItem
import com.sangwon.greenswitch.apiholder.NewDialog
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.dialog_item_click.*
import kotlinx.coroutines.launch


class MainActivity : AppCompatActivity() {
    var departList = mutableListOf<GetEmployApiItem>()
    var sortList = mutableListOf<MenuListItem>()
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val sortMenuList = mutableListOf<String>("All")

        lifecycleScope.launch {
//            .map { it.LastName!!.toLowerCase() }
            val filter = Api.api.allDepartmentList()
            for(i in filter.indices){
                filter[i].LastName = filter[i].LastName?.toLowerCase()
            }
            val realFilter = filter.toMutableList().sortedBy { it.LastName.toString() }
            departList = realFilter as MutableList<GetEmployApiItem>

            sortList = Api.api.departmentMenuList()
            sortList.forEach {
                sortMenuList.add(it.Name)
            }
            ArrayAdapter<String>(
                this@MainActivity, android.R.layout.simple_spinner_dropdown_item,
                sortMenuList
            ).also { adapter ->
                spinner.adapter = adapter
            }
            spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
                override fun onNothingSelected(p0: AdapterView<*>?) {

                }

                override fun onItemSelected(p0: AdapterView<*>?, p1: View?, pos: Int, p3: Long) {
                    val sort = sortList.find { it.Name == sortMenuList[pos] }

                    if (sort == null) {
                        Toast.makeText(this@MainActivity, "All", Toast.LENGTH_SHORT).show()
                        (rv_main.adapter as MainAdapter).apply {
                            dataList = departList
                            txtMessage.setText("");
                            notifyDataSetChanged()
                        }
                        return
                    }
                    (rv_main.adapter as MainAdapter).apply {

                        Toast.makeText(this@MainActivity, "${sort.Name}", Toast.LENGTH_SHORT).show()
                        dataList =
                            departList.filter { it.DepartmentId?.toInt() == sort?.DepartmentId!! }


                        if(dataList.isEmpty()){
                            txtMessage.setText("No Employee In the department");

                        }else{
                            txtMessage.setText("");

                        }
                        notifyDataSetChanged();
                    }
                }
            }



            rv_main.adapter = MainAdapter(departList) { pos ->
                NewDialog(this@MainActivity).apply {
                    setContentView(R.layout.dialog_item_click)
                    btn_call.setOnClickListener {
                        val intent = Intent(Intent.ACTION_DIAL)
                        if (departList[pos].CellPhone != null)
                            intent.data = Uri.parse("tel:${departList[pos].CellPhone}")
                        else
                            intent.data = Uri.parse("tel:5065885609")
                        if (intent.resolveActivity(packageManager) != null) {
                            startActivity(intent)
                        }
                    }
                    textEmail.setText(departList[pos].EmailAddress);
                    textOfficeNumber.setText(departList[pos].CellPhone);

                    btn_email.setOnClickListener {
                        val intent = Intent(Intent.ACTION_SENDTO)
                        intent.type = "message/rfc822"

//                            intent.putExtra(Intent.EXTRA_EMAIL, "clubwonni@gmail.com")
//                            intent.putExtra(Intent.EXTRA_EMAIL, departList[pos].EmailAddress)

                        if (departList[pos].EmailAddress != null)
                            intent.data = Uri.parse("mailto:${departList[pos].EmailAddress}")
                        else
                            intent.data = Uri.parse("mailto:pleasgogo@gmail.com")

                        intent.putExtra(Intent.EXTRA_SUBJECT, "Any subject if you want")
                        intent.setPackage("com.google.android.gm")

                        if (intent.resolveActivity(packageManager) != null) startActivity(
                            intent
                        ) else Toast.makeText(
                            this@MainActivity,
                            "Gmail App is not installed",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                    show()
                }
            }


        }

    }
}