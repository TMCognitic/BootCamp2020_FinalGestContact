using GestContact.API.Models.Global.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.API.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private const string PassPhrase = "wB4fEP_vkM7FY=cL7SzFDQzY86s6-er7msnkPurgq=fL*p3GGQQ-JrfQaH&Spb3F=A2$BmFYw55QeEuqe@Yp&6u^39tPnwWEDh+jgk8-fL@D-BDvaJHgrP@FV%mvW^dPNkAu3qRAGy+T_3CKB%E9kRM!4&#CMS4Psg6CnB++PLx^q6L5+W_@aYf%TkRe3SXcSTH3^6wkeXgwHxHR*8sKLSMG^akd=5ryZag@V?Myttm^JV$sN3Dq+MU$ZVx+qn6Zp@NvqGB37FqgdTKSaE%ef4r9G3pDHjZvqY_HB87rLnS+F^#^xHZ9x5@DS%N?e%j&8u7fp2cqAYSJqg?d3z7?X-Zmu5e&8SHR6+J&&Dc!He*%6KQ4K%bVzewDMMHzhNR+@$?FY*@de?YV#CJHqnfC22mpwkkVbJatha%MV26SNcBtV_MF5M^2vkbhpW8-RV35!SG*mqrmCnE6t#6mYCAvxgz8f!!ntZbQM#D87sRT6-tKzWkQCEM#B52wmvueJtnHV8Njp6vSR=PJRu6P_dwGf6Wp4VWwHU&@v6AJSXstZYf3-%xj8bs^&kWgBJtsR_DY*#tNmdvhzZk$xXz=PBu8xu@pa-4Gv3EH&CvRd?7zPqV@Mk*qU&3f+yqYbJ2EGquf+b%rkSW%8GS^DznEynRrbhy?%u7bUFBA?jpSnXU5%^?ks$A=qCXh?$v^xYZ3pDkD?@+k$X@9mbHAUFf?@tP-hyHBJUEcY$=LREbgHbqcT&u5dTPenv#-g#ntNvTnmkVujj6BCHk@FQXG&YX%_rTnFRQD6Rjfm9TmqTNw3t-b-j2u8tS@QC%^yh6kQWR^4GvRgpS_pV^$v#K_Ar&93smg@2nw3RXfLnXjJ&_vr%s*Y?94dBRDDmqB8fHQUQH!=_N6EwRPQqs2k_N2w^N8!f=vp4%#PrDrCQ^K&_a+udEa27^sbCgQT^N6kvJe9MPVGu9+s-B_+htmTkMpdSBdC6V9bJgs*Sdtwh4^F56*-^=D-p_W6J5F#Vh=pA4H5PQKnc2=Gt?f?_s*R4^=9#yzDK*TZcLZcHXdmcV=njdcdjmJsgXaexLUFk$UkGyvvYk?^FKM*r4eRzmnZdpFd^&&R*DHH!h7Knb3Ttvvv$xFdEf5uQJ_bPWjTRzHdBXyz46rK8tqD!h-HPvhvJ#WGLqPjhnCBwHkK#as%J_ChRge-gdncdDMVvDYftKXQF4N=8mj=%UWUkfdZwhfnAXps7U%$feJ+7yC=bQk#W@%a%PX-x7eDVbCLNn2rnxEqeYr*RF&jh65yr_S4xwm?GyA^zCXKhdZzFzp694vK&MvJSW?ny+Cp%2RjN%36TcLDeT#4_Sf963K9DZEcmtSXWgGMb-7@=SQUNEWcZ@KZ4xS!eAe4Cy7n*NtYh6w8Ukw6x!p!6KhZmLtrRAc%CKDb6Dy5c&JDhbG!F-EFjXY3T_tM!zGT=9-wQ#LpY7dCaQ#BwbFjJ4NnD$Jb5^ZtP5$=B+JvZ!gV*qxQ&jZhTxak-M-PJN+XgHbe?dtLJPZQnAdNVy*H4@ZtdbFGcE-Sq?6wQkw3SW$a^#4E5E^_9bq*vx2tUHkGk$QVrUFU*+L6nnAXPqKvM2?f=#c&!=_=#7vnbcBT=XT!7$!^N*ydqd%b^PLqAJ3XKbQd_8hG5D%U3MMpM=rcB%Ed!*SJ5CwaH*gNgmK$JAxbTKzfEGDY9Ra7v+LVZdepBuXn4gpQqRQxda@pr+!_HCzw^+jRRyc&c4CUA$5pN_Z%Y%t9a&Wyxf#N8sEY!2UbG&JzqGHpj=NrbJFWJmYBL-?RZ+xdjbN24YGh7AUrm-RQ_DB2NmJMW-Ax*c7bB9bz^bV5pK533+TQ3pREYD-=*$2pND8wAwdMhpRmBkp-_-22LJVV2!rd52jf?&mtTtFXf-nd$wbY_ATcBFyjG+TB84Ckf4A5G!4cL@w%Y29gWmnRAjuyE&Pz*eu-H$eA_s59gN?+g2&wT?j?+J5xNWmDVfsF^$HBmJNXKGqJ+d^-Le^mL^&$3#&CtvV&MQZ7C3DYSJRN&Y%zjX-sM&D*hJxp57!+77Z";
        private const string Prefixe = "Bearer ";

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;

        private JwtSecurityTokenHandler Handler 
        { 
            get 
            {
                return _handler ??= new JwtSecurityTokenHandler();             
            } 
        }
        private JwtHeader Header
        {
            get {
                return _header ??= new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)),
                        SecurityAlgorithms.HmacSha512));
            }
        }

        public string GenerateToken(Customer user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                header: Header,
                payload: new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Email", user.Email),
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1))
                );
            return $"{Prefixe}{Handler.WriteToken(jwtSecurityToken)}";
        }

        public Customer ValidateToken(string token)
        {
            Customer user = null;

            token = token.Replace(Prefixe, "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            DateTime now = DateTime.Now;
            if (jwtSecurityToken.ValidFrom <= now && jwtSecurityToken.ValidTo >= now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string compareToken = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if (token == compareToken)
                {
                    payload.TryGetValue("Id", out object id);
                    payload.TryGetValue("LastName", out object lastname);
                    payload.TryGetValue("FirstName", out object firstname);
                    payload.TryGetValue("Email", out object email);

                    user = new Customer()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastname,
                        FirstName = (string)firstname,
                        Email = (string)email
                    };
                }
            }

            return user;
        }
    }
}
