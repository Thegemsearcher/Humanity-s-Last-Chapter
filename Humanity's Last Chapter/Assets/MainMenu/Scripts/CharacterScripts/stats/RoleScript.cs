using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleScript : MonoBehaviour {

    public enum RoleCategory {
        Govement,
        Military,
        Support,
        Civilian
    }

    private RoleObject role;
    private CharacterScript characterScript;
    private Stats stats;
    private PortraitScript portraitScript;

    private void Start() {
        characterScript = GetComponent<CharacterScript>();
        stats = GetComponent<Stats>();
        portraitScript = GetComponent<PortraitScript>();
        role = characterScript.role;

        if (role != null) {
            portraitScript.Background.GetComponent<Image>().sprite = role.portraitBackground;
        } else {
            portraitScript.NoRole();
        }
    }

    public void ChangeRole(RoleObject newRole) {
        if (role != null) {
            ChangeStats(role, -1);
        }
        ChangeStats(newRole, 1);
        role = newRole;
        characterScript.role = role;

        if (role != null) {
            portraitScript.Background.GetComponent<Image>().sprite = role.portraitBackground;
        } else {
            portraitScript.NoRole();
        }
    }

    private void ChangeStats(RoleObject role, int modifier) {
        stats.maxHp += (role.maxHp * modifier);
        stats.str += (role.str * modifier);
        stats.def += (role.def * modifier);
        stats.Int += (role.Int * modifier);
        stats.dex += (role.dex * modifier);
        stats.cha += (role.cha * modifier);
        stats.ldr += (role.ldr * modifier);
        stats.nrg += (role.nrg * modifier);
        stats.snt += (role.snt * modifier);
    }
}
