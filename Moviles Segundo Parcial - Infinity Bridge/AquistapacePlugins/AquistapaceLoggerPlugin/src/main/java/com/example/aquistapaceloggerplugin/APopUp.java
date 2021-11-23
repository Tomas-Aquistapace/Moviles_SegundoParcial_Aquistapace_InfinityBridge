package com.example.aquistapaceloggerplugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;
import android.view.WindowManager;

public class APopUp
{
    private static final APopUp ourInstance = new APopUp();
    private static final String TAG = "APopUp";

    public static APopUp getInstance() { return ourInstance; }

    public static Activity mainActivity;

    public interface AlertViewCallback {
        public void onButtonTapped(int id);
    }

    public void ShowAlertView(String[] strings, final AlertViewCallback callback)
    {
        Log.i(TAG, "Entro a la ventana");

        if(strings.length < 3)
        {
            Log.i(TAG, "Error - expected at least 3 strings, got " + strings.length);
            return;
        }

        DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int id)
            {
                dialogInterface.dismiss();
                Log.i(TAG, "Tapped: " + id);
                callback.onButtonTapped(id);
            }
        };

        AlertDialog alertDialog = new AlertDialog.Builder(mainActivity)
                .setTitle(strings[0])
                .setMessage(strings[1])
                .setCancelable(false)
                .create();

        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL, strings[2], myClickListener);
        if(strings.length > 3)
            alertDialog.setButton(AlertDialog.BUTTON_NEGATIVE, strings[3], myClickListener);
        if(strings.length > 4)
            alertDialog.setButton(AlertDialog.BUTTON_POSITIVE, strings[4], myClickListener);
        alertDialog.show();
    }
}