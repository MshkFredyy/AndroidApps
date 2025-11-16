package com.example.myapplication

import android.Manifest
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.net.Uri
import android.os.Build
import android.os.Bundle
import android.provider.Settings
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContracts
import androidx.annotation.RequiresPermission
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.app.NotificationCompat
import androidx.core.app.NotificationManagerCompat
import androidx.core.content.ContextCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.example.myapplication.databinding.ActivitySettingsBinding

class SettingsActivity : AppCompatActivity() {
    private lateinit var binding: ActivitySettingsBinding
    private lateinit var permissionLauncher: ActivityResultLauncher<Array<String>>

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivitySettingsBinding.inflate(layoutInflater)
        setContentView(binding.root)


        permissionLauncher = registerForActivityResult(ActivityResultContracts.RequestMultiplePermissions()) { perms ->
            perms.entries.forEach {
                if (!it.value) {
                    showPermissionSettingsDialog(it.key)
                }
            }
        }

        binding.btnToggleContactsPermission.setOnClickListener {
            togglePermission(Manifest.permission.READ_CONTACTS)
        }

        binding.btnToggleGalleryPermission.setOnClickListener {
            togglePermission(Manifest.permission.READ_EXTERNAL_STORAGE)
        }

        binding.btnBack2Main.setOnClickListener {
            finish()
        }

    }
    private fun togglePermission(permission: String) {
        if (ContextCompat.checkSelfPermission(this, permission) == PackageManager.PERMISSION_GRANTED) {
            // Разрешение уже есть — пригласить пользователя удалить вручную (прямого удаления нет)
            showPermissionSettingsDialog(permission)
        } else {
            // Запросить разрешение
            permissionLauncher.launch(arrayOf(permission))
        }
    }
    private fun showPermissionSettingsDialog(permission: String) {
        val builder = android.app.AlertDialog.Builder(this)
        builder.setTitle("Разрешение требуется")
        builder.setMessage("Пожалуйста, перейдите в настройки, чтобы удалить или разрешить доступ для $permission")
        builder.setPositiveButton("Открыть настройки") { _, _ ->
            val intent = Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS)
            intent.data = Uri.parse("package:$packageName")
            startActivity(intent)
        }
        builder.setNegativeButton("Отмена", null)
        builder.show()
    }

}