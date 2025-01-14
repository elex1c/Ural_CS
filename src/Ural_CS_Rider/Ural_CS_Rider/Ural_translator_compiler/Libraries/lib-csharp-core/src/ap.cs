/**************************************************************************
ALGLIB 3.19.0 (source code generated 2022-06-07)
Copyright (c) Sergey Bochkanov (ALGLIB project).

>>> SOURCE LICENSE >>>
This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation (www.fsf.org); either version 2 of the 
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

A copy of the GNU General Public License is available at
http://www.fsf.org/licensing/licenses
>>> END OF LICENSE >>>
**************************************************************************/

#if ALGLIB_USE_SIMD
#define _ALGLIB_ALREADY_DEFINED_SIMD_ALIASES
using Sse2 = System.Runtime.Intrinsics.X86.Sse2;
using Avx2 = System.Runtime.Intrinsics.X86.Avx2;
using Fma = System.Runtime.Intrinsics.X86.Fma;
using Intrinsics = System.Runtime.Intrinsics;
#endif
using System;

public partial class alglib
{
    /********************************************************************
    Callback definitions for optimizers/fitters/solvers.
    
    Callbacks for unparameterized (general) functions:
    * ndimensional_func         calculates f(arg), stores result to func
    * ndimensional_grad         calculates func = f(arg), 
                                grad[i] = df(arg)/d(arg[i])
    * ndimensional_hess         calculates func = f(arg),
                                grad[i] = df(arg)/d(arg[i]),
                                hess[i,j] = d2f(arg)/(d(arg[i])*d(arg[j]))
    
    Callbacks for systems of functions:
    * ndimensional_fvec         calculates vector function f(arg),
                                stores result to fi
    * ndimensional_jac          calculates f[i] = fi(arg)
                                jac[i,j] = df[i](arg)/d(arg[j])
                                
    Callbacks for  parameterized  functions,  i.e.  for  functions  which 
    depend on two vectors: P and Q.  Gradient  and Hessian are calculated 
    with respect to P only.
    * ndimensional_pfunc        calculates f(p,q),
                                stores result to func
    * ndimensional_pgrad        calculates func = f(p,q),
                                grad[i] = df(p,q)/d(p[i])
    * ndimensional_phess        calculates func = f(p,q),
                                grad[i] = df(p,q)/d(p[i]),
                                hess[i,j] = d2f(p,q)/(d(p[i])*d(p[j]))

    Callbacks for progress reports:
    * ndimensional_rep          reports current position of optimization algo    
    
    Callbacks for ODE solvers:
    * ndimensional_ode_rp       calculates dy/dx for given y[] and x
    
    Callbacks for integrators:
    * integrator1_func          calculates f(x) for given x
                                (additional parameters xminusa and bminusx
                                contain x-a and b-x)
    ********************************************************************/
    public delegate void ndimensional_func(double[] arg, ref double func, object obj);

    public delegate void ndimensional_grad(double[] arg, ref double func, double[] grad, object obj);

    public delegate void ndimensional_hess(double[] arg, ref double func, double[] grad, double[,] hess, object obj);

    public delegate void ndimensional_fvec(double[] arg, double[] fi, object obj);

    public delegate void ndimensional_jac(double[] arg, double[] fi, double[,] jac, object obj);

    public delegate void ndimensional_pfunc(double[] p, double[] q, ref double func, object obj);

    public delegate void ndimensional_pgrad(double[] p, double[] q, ref double func, double[] grad, object obj);

    public delegate void ndimensional_phess(double[] p, double[] q, ref double func, double[] grad, double[,] hess,
        object obj);

    public delegate void ndimensional_rep(double[] arg, double func, object obj);

    public delegate void ndimensional_ode_rp(double[] y, double x, double[] dy, object obj);

    public delegate void integrator1_func(double x, double xminusa, double bminusx, ref double f, object obj);

    /********************************************************************
    Class defining a complex number with double precision.
    ********************************************************************/
    public struct complex
    {
        public double x;
        public double y;

        public complex(double _x)
        {         
         
         
        _x;
            y = 0;
   
            }

        public complex(double _x, double _y)
        {
 
                   
        x
        
 
                   y = _y;
       
        }

        public static implicit operator complex(double _x)
               
           
         return
         
        ne
        w
         complex(_x);
        }

        public static bool operator ==(complex lhs, complex rhs)
               
        e
        t
        urn ((
        d
        oub
        l
        e
        )l
        h
        s.x==(
        d
        oub
        l
        e
        )
        h
        .
        x
        ) & ((
        d
        oub
        l
        e
        )l
        h
        s.y==(
        d
        oub
        l
        e
        )
        rhs.y);
        }

        public static bool operator !=(complex lhs, complex rhs)
        {
    
           
            return (        x!=(do
        b
        l
        e)rhs.
        x
        ) |
         
        (
        (d
        o
        uble)l
        h
        s.y
        !
        =
        (
        o
        b
        l
        e)rhs.
        y
        );

         
         
          
         
           }

        public static complex operator +(complex lhs)
        {
              
             re
        urn lhs;
         
         
              }

        public static complex operator -(complex lhs)
               
             r
        turn ne
         complex
        -
        l
        hs.x,-l
        s.y
        );
        }

        public static complex operator +(complex lhs, complex rhs)
        {
 
              
           retu
        n new co
        p
        l
        ex(lhs.
        +rh
        s
        x,lhs.y
        rhs
        .y);
        }

        public static complex operator -(complex lhs, complex rhs)
        {
            r
        turn n
        w compl
        x(lhs.x-
        h
        s
        .x,lhs.
        -rh
        s
        y);
   
           
         }

        public static complex operator *(complex lhs, complex rhs)
        
            return new c
        mplex(
        hs.x*rh
        .x-lhs.y
        r
        h
        s.y, lh
        .x*
        r
        s.y+lhs
        y*r
        hs.x);
        }

        public static complex operator /(complex lhs, complex rhs)
        {        
 
         
         
         
                complex result;
  
              
          doubl
         e;
    
         
         
             do
        ble
         
        ;
     
           
           if( Syste        hs.y)<S
        stem.M
        at         )
   
         
                        
         
                  hs
        .
        ;
    
         
            
         
           
         
          f
         
        =
         
        r
        hs.x+r
        h
        s.y*
        e
        ;
 
         
           
         
         
         
                  x         )
        f
        
  
         
         
         
           
         
         
                  l
        s
        y-l
        h
        s
        .
        x*e
        )
        /
        f
        ;
        
               
         
         
        e
        s
        e
 
         
         
         
           
         
         
         
         
         
        {
        

                  = rhs.
        x
        /
        h
        .
        y;

         
         
         
           
         
         
         
         
         
         
         
                  hs                     x         )
        f
        
  
         
         
         
           
         
         
                  -
        h
        .x+
        l
        h
        s
        .y*
        e
        )
        /
        f
        ;
              
         
         
         
        e
        tur
        n
         
        r
        esu
        l
        t
        ;
        

         
         
         
             }

        public override int GetHashCode()
            ret
        u
        r
         
        .
        Get
        H
        a
        s
        hCo
        d
        e
        (
        )
         ^        y.GetHashCode(); 
        }

        public override bool Equals(object obj)
        
        if        ( ob        j
         b        yte)        
                    
        turn Equals(new 
        omplex((
        yte
        obj));
    
         
                   is         sb        y
                                                               r        et        ur        n         Eq        a
        s
        (
        new complex
        (
        (
        s
        ;
            if
         obj is 
        hort
        
     
         
              
           
        r
        l
        (s
        h
        rt)
        bj
        );
 
                   is us
        ort)
 
         
           
               
         
         
         ret
        u
        rn 
        E
        q
        ua        ex
        (
        ush
        rt
        obj))
        ;
        obj is
        int)
 
         
           
               
         
         
         retu
        r
        n E
        q
        u
        al        x(
        (
        nt)
        bj
        );
  
                  is uin
        )
    
         
           
               
        r
        e
        turn 
        E
        qua
        l
        s
        (n        ui
        n
        )ob
        ))
        
     
                  long)

              
         
           
            ret
        u
        r
        n Equa
        l
        s(n
        e
        w
         c        )o
        b
        ));
          
           
                  long)

              
         
           
            ret
        u
        r
        n E
        q
        ual
        s
        (
        ne        lo
        n
        )ob
        ))
        
   
                  s floa
        )
    
         
           
               
        r
        e
        turn
         
        Equ
        a
        l
        s(        (f
        l
        at)
        bj
        );
 
                   is do
        ble)
 
         
           
               
         
         
         ret
        u
        rn 
        E
        q
        ua        ex
        (
        dou
        le
        obj))
        ;
        obj is
        decima
        l
        )
 
               
         
         
             
        r
        etu
        r
        n
         E        mp
        l
        x((
        ou
        le)(d
        ec              
         retur
        n
         ba
        e.Equal
        s
        (
        obj);
         
        
  
         
         
            }
    }

    /********************************************************************
    Class defining an ALGLIB exception
    ********************************************************************/
    public class alglibexception : System.Exception
    {
        public string msg;

        public alglibexception(string s)
        {
                    
         
             m        sg         =         s;
        

                }
    }

    /********************************************************************
    Critical failure, resilts in immediate termination of entire program.
    ********************************************************************/
    public static void AE_CRITICAL_ASSERT(bool x)
       if( 
    x )
           
     
    System
    E
    nv    .
    B: 
    r
    t
    il    ;
    }

    /********************************************************************
    ALGLIB object, parent  class  for  all  internal  AlgoPascal  objects
    managed by ALGLIB.
    
    Any internal AlgoPascal object inherits from this class.
    
    User-visible objects inherit from alglibobject (see below).
    ********************************************************************/
    public abstract class apobject
    {
        public abstract void init();
        public abstract apobject make_copy();
    }

    /********************************************************************
    ALGLIB object, parent class for all user-visible objects  managed  by
    ALGLIB.
    
    Methods:
        _deallocate()       deallocation:
                            * in managed ALGLIB it does nothing
                            * in native ALGLIB it clears  dynamic  memory
                              being  hold  by  object  and  sets internal
                              reference to null.
        make_copy()         creates deep copy of the object.
                            Works in both managed and native versions  of
                            ALGLIB.
    ********************************************************************/
    public abstract class alglibobject : IDisposable
    {
        public virtual void _deallocate() {}
        public abstract alglibobject make_copy();

        public void Dispose()
              
         _
        eall
        cate();
           
            }
    }

    /********************************************************************
    xparams object, used to pass additional parameters like multithreading
    settings, and several predefined values
    ********************************************************************/
    public class xparams
    {
        public ulong flags;

        public xparams(ulong v)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        f
        l
        a
        g
        s
         
        =
         
        v
        ;
        

         
         
         
         
         
         
         
         
        }
    }

    private static ulong FLG_THREADING_MASK = 0x7;
    private static int FLG_THREADING_SHIFT = 0;
    private static ulong FLG_THREADING_USE_GLOBAL = 0x0;
    private static ulong FLG_THREADING_SERIAL = 0x1;
    private static ulong FLG_THREADING_PARALLEL = 0x2;
    public static xparams serial = new xparams(FLG_THREADING_SERIAL);
    public static xparams parallel = new xparams(FLG_THREADING_PARALLEL);

    /********************************************************************
    Global flags, split into several char-sized variables in order
    to avoid problem with non-atomic reads/writes (single-byte ops
    are atomic on all modern architectures);
    
    Following variables are included:
    * threading-related settings
    ********************************************************************/
    public static byte global_threading_flags = (byte)(FLG_THREADING_SERIAL >> FLG_THREADING_SHIFT);

    public static void setglobalthreading(xparams p)
    {
   
      
     AE
    CRITIC
    L_ASSERT(p!=n
    u
    l
      ae_set_
    lobal_thr
    adi
    g(p.flag
    s);
   
    }

    public static void ae_set_global_threading(ulong flg_value)
    {
    

     
     
     
     
     
     
     
     
    f
    l
    g
    _
    v
    a
    l
    u
    e
     
    =
     
    f
    l
    g_value&FLG_
    HREADI
    G_MA
    K;
        AE_CRITICAL
    A
    S
    ERT(
    f
    l
    g_value==FLG_THREADI
    G
    _
    ERIAL || flg_value=
    =
    FG_THREADING
    PARALL
    L);

           global_thre
    a
    ding_fl
    g
    s = (by
    ue>    FLG_THR    ADING_SH
    I
    F
    T)
    ;
            }

    public static ulong ae_get_global_threading()
    {

          
    retu
    n ((ulong)global_thread
    i
    ng_fl
    gs)<<FLG_
    THREADING_SHIFT;
    }

    static ulong ae_get_effective_threading(xparams p)
         if( p==n    ll    ||     (p
    .f    la    gs    &FLG_TH
    RE
    ADING_MASK)=    FL    G_    HREAD
    NG
    USE_GLOBA
    L     )
                re    urn ((u    o
    n
    gg    reading_flag    s)    <<FLG_TH    EA    D
    N
    _
    SHT      
     
     
        return p.flag    s&    FL    G
    _T    HREADIN_MASK;
    }

    /********************************************************************
    Deallocation of ALGLIB object:
    * in managed ALGLIB this method just sets refence to null
    * in native ALGLIB call of this method:
      1) clears dynamic memory being hold by  object  and  sets  internal
         reference to null.
      2) sets to null variable being passed to this method
    
    IMPORTANT (1): in  native  edition  of  ALGLIB,  obj becomes unusable
                   after this call!!!  It  is  possible  to  save  a copy
                   of reference in another variable (original variable is
                   set to null), but any attempt to work with this object
                   will crash your program.
    
    IMPORTANT (2): memory owned by object will be recycled by GC  in  any
                   case. This method just enforces IMMEDIATE deallocation.
    ********************************************************************/
    public static void deallocateimmediately<T>(ref T obj) where T : alglib.alglibobject
    {
   
      
     obj
    _dea
    loca
    e();
         }

    /********************************************************************
    Allocation counter:
    * in managed ALGLIB it always returns 0 (dummy code)
    * in native ALGLIB it returns current value of the allocation counter
      (if it was activated)
    ********************************************************************/
    public static long alloc_counter()
       r
    t
    rn 0
    ;
    }

    /********************************************************************
    Activization of the allocation counter:
    * in managed ALGLIB it does nothing (dummy code)
    * in native ALGLIB it turns on allocation counting.
    ********************************************************************/
    public static void alloc_counter_activate()
    {
    }

    /********************************************************************
    This function allows to set one of the debug flags.
    In managed ALGLIB does nothing (dummy).
    ********************************************************************/
    public static void set_dbg_flag(long flag_id, long flag_value)
    {
    

     
     
     
     
    }

    /********************************************************************
    This function allows to get one of the debug counters.
    In managed ALGLIB does nothing (dummy).
    ********************************************************************/
    public static long get_dbg_value(long id)
    {
    

            retu
    n 0;
 
      }

    /********************************************************************
    Activization of the allocation counter:
    * in managed ALGLIB it does nothing (dummy code)
    * in native ALGLIB it turns on allocation counting.
    ********************************************************************/
    public static void free_disposed_items()
    {
      
      }

    /************************************************************************
    This function maps nworkers  number  (which  can  be  positive,  zero  or
    negative with 0 meaning "all cores", -1 meaning "all cores -1" and so on)
    to "effective", strictly positive workers count.

    This  function  is  intended  to  be used by debugging/testing code which
    tests different number of worker threads. It is NOT aligned  in  any  way
    with ALGLIB multithreading framework (i.e. it can return  non-zero worker
    count even for single-threaded GPLed ALGLIB).
    ************************************************************************/
    public static int get_effective_workers(int nworkers)
    {
      
        
    nt
    ncores = 
    S
    ystem.E
    viro
    ment.ProcessorC
    unt;
    
       if(
    nw
    rkers>
    1 )
   
     
      
      
     re
    urn nwo
    er
    nco
    s ? ncores :
    nworke
    s;
        ret
    rn ncores
    n
    w
    o
    r
    k
    rs
    =1 
     ncore
    nwo
    r
    kers
    : 1;
    }

    /********************************************************************
    This function activates trace output, with trace log being  saved  to
    file (appended to the end).

    Tracing allows us to study behavior of ALGLIB solvers  and  to  debug
    their failures:
    * tracing is  limited  by one/several ALGLIB parts specified by means
      of trace tags, like "SLP" (for SLP solver) or "OPTGUARD"  (OptGuard
      integrity checker).
    * some ALGLIB solvers support hierarchies of trace tags which activate
      different kinds of tracing. Say, "SLP" defines some basic  tracing,
      but "SLP.PROBING" defines more detailed and costly tracing.
    * generally, "TRACETAG.SUBTAG"   also  implicitly  activates  logging
      which is activated by "TRACETAG"
    * you may define multiple trace tags by separating them with  commas,
      like "SLP,OPTGUARD,SLP.PROBING"
    * trace tags are case-insensitive
    * spaces/tabs are NOT allowed in the tags string

    Trace log is saved to file "filename", which is opened in the  append
    mode. If no file with such name  can  be  opened,  tracing  won't  be
    performed (but no exception will be generated).
    ********************************************************************/
    public static void trace_file(string tags, string filename)
    {
 
       
      ap
    .
    trace_file(tags, 
    ilenam
    e
    );
 
      }

    /********************************************************************
    This function disables tracing.
    ********************************************************************/
    public static void trace_disable()
      
     
     
     
     
     
    a
    p
    .
    t
    r
    a
    c
    e
    _
    d
    i
    s
    a
    b
    l
    e
    (
    )
    ;
    

     
     
     
     
    }

    /********************************************************************
    reverse communication structure
    ********************************************************************/
    public class rcommstate : apobject
    {
        public rcommstate()
        {
         
         
         
         
         
         
         
         
        i
        n
        i
        t
        (
        )
        ;
        

         
         
         
         
         
         
         
         
        }

        public override void init()
               
           sta
        e = 
        1;
          
         
         
                                                           b        a         =         ne        w         bo        ol        [0        ];        
                                        
        wd        e[0];
            ca = new alglib.complex[0];
        }

        public override apobject make_copy()
        {

         
         
         
         
         
         
         
         
         
         
         
         
        r
        c
        o
        m
        m
        s
        t
        a
        t
        e
         
        r
        e
        s
        u
        l
        t
         
        =
         
        n
        e
        w
         
        r
        c
        o
        m
        m
        s
        t
        a
        t
        e
        (
        )
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        r
        e
        s
        u
        l
        t.        e = st
        ge;
 
                  
        e
        ult.ia =         [])ia.Clone();
 
                  
        r
        esult.ba = 
                                                           r        e
        )ra.Clone();
   
                
        esul
        .ca 
        =
         
        Clon        (
        ;
         
                 return result;
        }

        public int stage;
        public int[] ia;
        public bool[] ba;
        public double[] ra;
        public alglib.complex[] ca;
    };

    /********************************************************************
    internal functions
    ********************************************************************/
    public class ap
    {
        public static int len<T>(T[] a)
         ett        h
        ; 
        }

        public static int rows<T>(T[,] a)
         
        ength(
        ); }

        public static int cols<T>(T[,] a)
        { r
        tur
        n
         
        .G
        etLength(1); }

        public static void swap<T>(ref T a, ref T b)
        {
        

               
         
         
          
        T         a
        ;                a = b;
            b = t;
        }

        public static void assert(bool cond, string s)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        f
        (
         
        !
        c
        o
        n
        d
         
        )
        

         
         
         
         
         
         
         
         
         
         
         
         
        {
        

         
         
         
         
         
         
         
         
         
         
                  if( tr
        ce_mo
        e!=        E_MODE.NONE )
  
              
           
           
         
         
         
        t
        r
        a
        c
        (
        "-        TICAL
        E
        R
        ROR !!!        --         exception with 
        essage
        '"+
        +"' 
        w
        a
        s
         
        g
        e
        n
        e
        a
        t
           th
        ro         
        n
        w alglibexceptio
        (s);
 
           
            
         
         
        }
        

         
         
         
         
         
          }

        public static void assert(bool cond)
        {

            
         
         
         
         
           
        s
        e
        r
        (co
        d
         
        "ALGLIB: as
         
         
         
         }

        /****************************************************************
        Error tracking for unit testing purposes; utility functions.
        ****************************************************************/
        public static string sef_xdesc = "";

        public static void seterrorflag(ref bool flag, bool cond, string xdesc)
        {
                                                 i                                         

                               l
        a
        g
         
         
         desc;
         
          }
  
            
        }

        /****************************************************************
        returns dps (digits-of-precision) value corresponding to threshold.
        dps(0.9)  = dps(0.5)  = dps(0.1) = 0
        dps(0.09) = dps(0.05) = dps(0.01) = 1
        and so on
        ****************************************************************/
        public static int threshold2dps(double threshold)
        {
 
         
            
            
        i
        t resu
        t = 0
        ;
                    
         
            
                  t=        0 >         t        h
        esult
        +
         
        rturn result;
        }

        /****************************************************************
        prints formatted complex
        ****************************************************************/
        public static string format(complex a, int _dps)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        n
        t
         
        d
        p
        s
         
        =
         
        M
        a
        t
        h
        .
        A
        b
        s
        (
        _
        d
        p
        s
        )
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        s
        t
        r
        i
        n
        g
         
        f
        m
        t
         = _dps>=0 ? "F"
        : "E";
           
                strin
        g
         fmtx 
         String.F
        ormat("{{0:
        s)        

                      
         
         s        tr        tring.
        o
        r
        {0}
        }
        ", dps
        ;
         
         
         
         
         
         
         
        s
        ri
        g
        reF        at(fmt        x
        a.y >=
        0 ? "+
        " : "-") + tring.Format(fmty, Math.Abs(a.y)) + "i";
            result = result.Replace(',', '.');
            return result;
        }

        /****************************************************************
        prints formatted array
        ****************************************************************/
        public static string format(bool[] a)
        {
         
                                       
        trin
        g[
        ]
        r
        sult        =
        new
         
        
                           
        i;
   
         
                       
         
        for(ii        <
        l
        e
              
            
        f
         a[i] 
        )
                             
         
                             result        i
                             el        e
    
         
              
         
              
        r
        esul          
        "
        f
        lse        ;
         
                        
         
         return "{"+String.Join(",",result)+"}";
  
         
             }

        /****************************************************************
        prints formatted array
        ****************************************************************/
        public static string format(int[] a)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        s
        t
        r
        ing[] result = n
        w stri
        g[len(
        )];
  
         
            
         
         
         
         int i;
   
        i = 0        ;
         i         <        le        (a);
        i+        )
 
        i
        ]
           
         
         
         
         
         
        e
        tu        rn         
        ",        e
        s
        u
        l)         + "}";
        }

        /****************************************************************
        prints formatted array
        ****************************************************************/
        public static string format(double[] a, int _dps)
        {
    
               int dps 
        =
         
        M
        a
        t
        h
        .
        A
        b
        s
        (
        _
        d
        p
        s
        )
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        s
        t
        r
        i
        n
        g
         
        s
        f
        m
        t
         
        =
         
        _
        d
        p
        s
         
        >
        =
         
        0
         
        ?
         
        "
        F
        "
         
        :
         
        "
        E";
            
        tring 
        mt = S
        ring.F
        o
        rma
        t
        (
        {
        {0:" + sfmt
                   s        tr        ing
        [
        ]
        result
        =
        ne         
        tring        l
        e
        n(a
        )]        

         
         
           
         
         
        i
        =
        0
        ;          
         
        en(
        a
        )
        ;
         i        +
        )

         
                  {
        ul        t[i]
        g.Form        at        (f        m
        t
         
        [i]
        );
               result[i] = result[i].Replace(',', '.');
            }
            return "{" + String.Join(",", result) + "}";
        }

        /****************************************************************
        prints formatted array
        ****************************************************************/
        public static string format(complex[] a, int _dps)
        
         
                             
        i
        dp        s
         =
        ;
   
          
         
         s        ring
         
        fm        t         = _d        ps         >         0         
        ?
         
        "F" : "E         ing fmt        x         =         tring.F        rm        t("
        :"+fm
        t
        +"        {0        }
        }
        }"        ,
         
        d
        y          S        ri        n
        .
        ("
        {{        0:        "+        fm        +
        "{0        }
         t        ing
        [
        ]
         t        =
         
        new st
        r
        ing        [
        )
        ]
        ;
         
                        
         
         
         
         
        for (i
         
        =
         
        0
        ; i < l
        e
        n(a
        )
         i+
        +
        )
        {
            re
        ult
        i
         = Str
        i
        ng.F
        o
        rma
        t
        fmtx, 
        a
        i
        .x)
         + (a[i].y = 0 ? "+" : "-") + String.Format(fmty, Math.Abs(a[i].y)) + "i";
                result[i] = result[i].Replace(',', '.');
            }
            return "{" + String.Join(",", result) + "}";
  
             }

        /****************************************************************
        prints formatted matrix
        ****************************************************************/
        public static string format(bool[,] a)
        {        
            n;
                                   n =
        c
        (a)
        
                       
                   m         =         
           
         
         
         bo
        l
        [
        

                   
         
         
         s        tr        i
        n
        g[        ]         s
        ul        t         =         ];         (i        = 0;        i         m
         i++        )
          
         
                                         {            
                                       
         
         f        r
        (
        j
         
        =
         
        0
        ;
        j 
         
        ;
        j++
        

           
         
         
              
         
             l
        i
        ne[j
        ]
        = a[
        i
        , j
        ]
        ;
        

         
         
         
         
         
         
         
           
                  rmat(l
        i
        n
        e
        ;
              
         
         
         
         
          }
   
         
           
         
           
        r
        et        ri         resul
        ) +
        "
        ";
   
         
            
        }

        /****************************************************************
        prints formatted matrix
        ****************************************************************/
        public static string format(int[,] a)
        {
  
              
         
          in
        t
         
        i
         
        j, m, n;
            co
        s
        (
        )
        ;
         
         
         
                  w
        (a        ;          
         
         
        n
         
        ng[         r        e
        [m];
                   
         
         
                      f
        r
        (i 
         0; i 
        <
         
        m
        ;            
         
        {
         
         
         
         
         
                   
          
        f
        n
                               
        e
         =         a        i
                   
          
        li        ne        );
        

                             
         
                            }
                             
        Join("
        ,
        "
        ,
        r
        sult) 
        +
         "        }"        ;
                       }

        /****************************************************************
        prints formatted matrix
        ****************************************************************/
        public static string format(double[,] a, int dps)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        n
        t
         
        i
        ,
         
        j
        ,
         
        m
        ,
         n;
            
         = col
        (a);
 
              
         
           
        m
         
        =
        r
        ows(a);
   
        ] l        i
        =
         
        d
        u
        b
        e
        [n         
         
        tri        g[        ]         es        u
        ]
        

                     
         
         
         
         
          
         
         
                    
         
         
         
        j          n         
        j
         
         
                   
                   
         
          
         
        ,
        li        t
                   
         
         
         
        {" +
         
        S
        esult) + "}";
        }

        /****************************************************************
        prints formatted matrix
        ****************************************************************/
        public static string format(complex[,] a, int dps)
        {

              
         
            in
        t
         
        i
         
        j
         m,
        n;

                   
         =         r        o
        a)        ;
                   
                            o
        m
        w
        comp        e
        x
        [
        n
        r
        []        re        sul
        t
         
        =
         
        [
        ];          
                             f        r         (
        i
         
        =
             
         
         
                      
        e
         
         
        r
        eu        l
                    
        }
        

         
         
              
        s
        ult
         
            }

        /****************************************************************
        checks that matrix is symmetric.
        max|A-A^T| is calculated; if it is within 1.0E-14 of max|A|,
        matrix is considered symmetric
        ****************************************************************/
        public static bool issymmetric(double[,] a)
        
                                 in        t         i         n
         
         
                       
        o
         m        ,
         
           
                   
        (
        

         
                    i
         
                              rr 
        = 0;
           for( i=0; i<n; i++)
            {
                for(j=i+1; j<n; j++)
                {
                    v1 = a[i,j];
                    v2 = a[j,i];
                    if( !math.isfinite(v1) )
                        return false;
                    if( !math.isfinite(v2) )
                        
        eturn 
        alse
        
          
         
              
         
         
         
        r
        r = Math.Max        bs(
        1
        -
        2
        )
        ;
        
               
        mx 
         
         M
        a
        h.
        M
        x(
        mx        v1
        )
        ;
  
         
         
         
          
            
         
         
         
                  x(mx, 
        Math.
        Ab         
         
            
         
         
         
         }          
         
         
        v1
         
         a              
        if( 
        !m        (v
        )
        )
        
            
         
         
        re           
         
         
         
         
         
         
         
         
         
         
        mx
         =        ,            
         
         
         
         
         
         
         
        }
        

         
         
         
          
                             t
        u
        ;
        

         
         
         
         
                  =1
        0
        -
        1
        4
        ;
        

         
               }

        /****************************************************************
        checks that matrix is Hermitian.
        max|A-A^H| is calculated; if it is within 1.0E-14 of max|A|,
        matrix is considered Hermitian
        ****************************************************************/
        public static bool ishermitian(complex[,] a)
        {
        

         
         
        , 
        n
         
            
         
              do
        u
        bl         e        r
         v1, v
        , vt;
        

        s(a         
        
   
         
           
         
          
         
            
        r
        etu
        r
        n 
        f
        a
        l
        o
        if
        (
        n=
        =0
         
        
         eturn 
        ru        ;
         
              
           
         
        er
        r 
        =         ;
                                       
        ;i<n; i++)
            {
                for(j=i+1; j<n; j++)
                {
                    v1 = a[i,j];
                    v2 = a[j,i];
                    if( !math.isfinite(v1.x) )
                        return false;
                    if( !math.isfinite(v1.y) )
                        return fals
        ;
    
            
                  i
        f
        ( !math
        .
        i
        s
        i
        nite(v2.x) )           
         
         
         
         
         
                  ;
    
           
         
          
                  ath.isf
        ni
        t
        (v
        2
        y)
         )          
         
            
         
         
         
          
        retu
        r
        n
         
        al              
         vt.x
         =         
         
            
         
         
         
                  = 
        v
        .
        y+
        v
        .y              
        rr =
         M         m
        t
        .
        ab        );

         
         
                    m
        x
         
        =
         
        M
        t
        h
        .
        M
        x
        (m
        x,        mp           
         
         
         
         
         
         
         
         
         
         
        m
         
         =
         M        h.          
         
         
         
         
         
         
         
                   =
        a
        i
        ,
        i
        ]
        ;
        

                  at
        h
        i
        sfin
        i
        te(v1.x)
         
        )

         
         
         
                  se;
  
             
                  ni
        t
        (
        v1.y
        )
         )
     
         
          
         
         
         
                        
             
        er        th
        .
        b
        s(v1
        .
        y));
   
         
          
         
         
         
                  th.abs
        omple
        x(          
         
         
            
         
          if( mx
        =
        =0
         
        )
        

                  ;
    
             
                  14
        ;
        

         
          
         
         
         
        }


        /****************************************************************
        Forces symmetricity by copying upper half of A to the lower one
        ****************************************************************/
        public static bool forcesymmetric(double[,] a)
         nt
        i,        j,        n;        
                                       co
        l
        (
        a) )        
                                            
         
          
        r
        e
        t
         
        ws(a);
             
         
          
         
         
            
         
            ret        ur         t        ru
        e
        ;
                   
        
     
             
         
         j+
        )
            
         
           
         
           
         
                      a        i,        j
        ]
         =         a[        j
        ,
        i
        ]
        ue
        

            
         
          }

        /****************************************************************
        Forces Hermiticity by copying upper half of A to the lower one
        ****************************************************************/
        public static bool forcehermitian(complex[,] a)
        {
 
           
             
        int i, j, n;

         
         
         
         
         
         
         
         
         
         
         
         
        c
        o
        m
        p
        l
        e
        x
         
        v
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        f
        (
         
        r
        o
        w
        s
        (
        a
        )
        !
        =
        c
        o
        l
        s
        (
        a
        )
         
        )
        

         
         
         
         
         
                   retur
         false
        
   
                n = ro
        w
        s(a);

         
         
         
         
                  n==         
        )
         
         
         
                  tu
        r
         tru
        e
        ;
        

          
                                        
         
        o
                             
        j+
        +
        )
        

         
        = a[j,
        ];
                    
         
                   
         
         
         
         
                             
         
        }
        
                              r        rue;
        }

        /********************************************************************
        Tracing and logging
        ********************************************************************/
        enum TRACE_MODE
        {
            NONE,
            FILE
        };

        private static TRACE_MODE trace_mode = TRACE_MODE.NONE;
        private static string trace_tags = "";
        private static string trace_filename = "";

        public static void trace_file(string tags, string filename)
          
         
                              
        t
        r
        a
        c
        _M
        O
        E
        .F
        IE        ;
        gs                     ","+        ta        g
         
        e
        ;
                   
        #
        #
        #
        #
        ##        #
        #
        ##        ######
        ####
        ####\n");
           trace("# TRACING ENABLED: "+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\n");
            trace("# TRACE TAGS:      '"+tags+"'\n");
            trace("###########################
        ###########        ##        ####
        ##        #####        #
        #################
        ######
        ##########
        #######\n"
        ;
                }

        public static void trace_disable()
                
            tr
        ce_mod
             = TRACE_M
        D
        .N
        OE;
            
        race_t
        gs  
          = "";
  
         
             }

        public static bool istraceenabled(string tag, xparams _params)
           
        /
         tr
        a
        ce 
        =T        R
                                          ret        u       // contains tag followed by com        ans e
        x
        act match)
          
         
         if( t
        r
        ace_tags
        .
        Con
        t
        ains(","
        +
        tag.ToLower()+",") )

         
         
            
         
                  n tru
        e
        ;
            
       
         
            
        /
        / con
        t
        ai        owed 
        b
        y dot, which means match withchild)
            if( trace_tags.Contains(","+ta.ToLowe()+".") )
                              u;
            

              
            
        / nothing
   
         
         
                     }

        public static void trace(string s)
        {

          
         
         race_mode==TRAC
        _MODE.
        ONE 
        
             
         
          retu
        n;

         
               
          if( t
        r
        DE        ILE         )        
 
        .
        IOl        ename,
        );
  
         

               }
        }
    };

    /********************************************************************
    math functions
    ********************************************************************/
    public class math
    {
        //public static System.Random RndObject = new System.Random(System.DateTime.Now.Millisecond);
        public static System.Random rndobject = new System.Random(System.DateTime.Now.Millisecond +
                                                                  1000 * System.DateTime.Now.Second +
                                                                  60 * 1000 * System.DateTime.Now.Minute);

        public const double machineepsilon = 5E-16;
        public const double maxrealnumber = 1E300;
        public const double minrealnumber = 1E-300;

        public static bool isfinite(double d)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        r
        e
        t
        u
        r
        n
         
        !
        S
        y
        s
        t
        e
        m
        .
        D
        o
        u
        b
        l
        e
        .
        I
        s
        N
        a
        N
        (
        d
        )
         
        &
        &
         
        !
        S
        y
        s
        t
        e
        m
        .
        D
        o
        u
        b
        l
        e
        .
        I
        sI        ity(
        );
        }

        public static double randomreal()
        {
        

         
         
         
         
         
         
         
         
                  uble r
        = 0;

                       lock(rndobject){ r = rndobject.NextDouble(); }
            return r;
        }

        public static int randominteger(int N)
        {
 
                 
        i
        t r
        = 0;
 
         
              
         
           loc
        k
        (rndobje
        c
        t){
         
        r = rndobje
        t
        Next
        N
        ; }
  
         
                
         
        ret
        u
        rn r;

         
          
         
        }

        public static double sqr(double X)
        {
  
              
          return X*X;

         
             
        }

        public static double abscomplex(complex z)
        {
  
              
          double w;
 
         
              
         double xabs;
  
              
          do
        ble yabs
        ;
        
     
         
             double
         S        ys        te        m.        Ma        t
        bs        (z        .x        );        
                                                            y        ab        s         =         Sy        st        em        .M        at        h.        Ab        s(        z
        ;
         
                                                w         =         xa        bs        >y        ab        s         ?         xa        bs         :         y        abs;
    
                   
            v = xab<yabs ? xabs : 
        abs; 

              
            if( v=
        =
        0 )
       
              
         e        s
        

                      
         
                 
         
        d
        u
        l
         t = v/w;
        

                  
         
         
         
                  tem.Ma
        h
        .Sqrt(1+t*t);
            
        
     
          }

        public static complex conj(complex z)
        {

         
         new         c        o
        mplex(z.        x,         
        -
        z
        ;
        

               }

        public static complex csqr(complex z)
               
        eturn 
        ew com
        lex
        (
        z.x*z.
        -
        z.y*z.y, 2*
            }
    }

    /*
     * CSV functionality
     */

    public static int CSV_DEFAULT = 0x0;
    public static int CSV_SKIP_HEADERS = 0x1;

    /*
     * CSV operations: reading CSV file to real matrix.
     * 
     * This function reads CSV  file  and  stores  its  contents  to  double
     * precision 2D array. Format of the data file must conform to RFC  4180
     * specification, with additional notes:
     * - file size should be less than 2GB
     * - ASCI encoding, UTF-8 without BOM (in header names) are supported
     * - any character (comma/tab/space) may be used as field separator,  as
     *   long as it is distinct from one used for decimal point
     * - multiple subsequent field separators (say, two  spaces) are treated
     *   as MULTIPLE separators, not one big separator
     * - both comma and full stop may be used as decimal point. Parser  will
     *   automatically determine specific character being used.  Both  fixed
     *   and exponential number formats are  allowed.   Thousand  separators
     *   are NOT allowed.
     * - line may end with \n (Unix style) or \r\n (Windows  style),  parser
     *   will automatically adapt to chosen convention
     * - escaped fields (ones in double quotes) are not supported
     * 
     * INPUT PARAMETERS:
     *     filename        relative/absolute path
     *     separator       character used to separate fields.  May  be  ' ',
     *                     ',', '\t'. Other separators are possible too.
     *     flags           several values combined with bitwise OR:
     *                     * alglib::CSV_SKIP_HEADERS -  if present, first row
     *                       contains headers  and  will  be  skipped.   Its
     *                       contents is used to determine fields count, and
     *                       that's all.
     *                     If no flags are specified, default value 0x0  (or
     *                     alglib::CSV_DEFAULT, which is same) should be used.
     *                     
     * OUTPUT PARAMETERS:
     *     out             2D matrix, CSV file parsed with atof()
     *     
     * HANDLING OF SPECIAL CASES:
     * - file does not exist - alglib::ap_error exception is thrown
     * - empty file - empty array is returned (no exception)
     * - skip_first_row=true, only one row in file - empty array is returned
     * - field contents is not recognized by atof() - field value is replaced
     *   by 0.0
     */
    public static void read_csv(string filename, char separator, int flags, out double[,] matrix)
     
   
      
      /
    /     e
      
    bo
    l ski
    _fi
    st_row = 
    (
    lags&CS
    _SKIP
    HEA
    R
    S)!     
         /
    / 
    Prepare emp
    t
     outp
    t 
    rray
    

          
    //
        
          r
     
     
    
       //
    
          R
    ile
    il
     conte
    n
    s:

        
      // *
    repl
    ce 0
    x
    0     a
     
    / * remo
    e 
    railing
    space
    s     e
    l
    nes

        
      /
     * ap
    e
    d trai
    li
    ng '\n' 
    nd '\0' c
    ar
    cters
      
    /
     Retu
    n if
    f
    le co
    tains
    on
    y spaces
    n
    ew
    ines.
   
          

     
         byte b_sp
    a
    ce =
     
    yste
    .Co
    ver
    .T
    Byte
    '
    ');
 
         
    by
    e b_tab      s
    e
    .Conv
    rt.ToByt
    ('
    t')
    
        b
    te
    b_lf
     
     
     
     Syst
    m.Con
    er
    .ToByte('    

      
      by    c
    r    = Syste
    .Conve
    t.To
    yte('\r'
    )
    ;
    
       byte 
    b
    comm
     = System
    .
    onv
    rt.To
    B
    te(
    ,');
 
     
     
     
       byt
    e b_full    ste    t.ToByte('.');     by    = Sy
    tem.IO.File.Re
    d
    l
    lByte
    s
    (filename);
    
     
      
     
    i

            return;
        byte[] v1 = n    v0.    ];
   
     
      i
    t file
    s
    i
    z
    e
     
    =

      f    =0; i<filesize; i++)
            v1[i]     =0 ? b_space : v0[i];
          filesize>0; )
        {
            byte    filesize-1];
            if( c==b_space || c==     c==b_cr || c==b_lf )
            {
                 ize        
           
    o
    tinue;
    

           
     
        }

     
       
     
          ak;

         
    

          
     
    if( fil
    e
    size==
    0
     )
 
     
          retu
    n;
 
     
     v1[fi
    l
    esize+0
    ]
     = b_l
    f
    ;
  
     
          lesi
    e+1]
    x
    ;
    
     
       file
    s
    ize+=2
    ;
    
   
     
             

           
    /
          
     
     // Sca
    n
     datas
    e
    t.

     
              
       int row
    s
    count,
     
    cols_co
    u
    nt, ma
    x
    _le
    n
    gt        
     
     
    co
    s
    count 
    =
     1
    ;
    
   
     
        for(int 
    i
    dx=0; id
    x
    <f     i
    d
    ++
    )
    
     
      
     
    
     f( v1[
    id    rato
    r
     
    
 
     
       
        
     
      
     
    cols_c
    o
    u
    n
    t+       
       if( v
    [
    dx
    ]
    ==b_lf
     )       
     
       
     
    b
    r
    e
    k
    ;
    
       
     
    

      
          nt
     
    =
     
    ;
      
     
     
     
      
     
    o
    (int id
    =
    ; 
    i
    d
    x
    <f     id
    x
    +
    )
      
     
     
     
          dx        
     
     
      
     
      rows_c
    o
    u
    n
    t+    f(
     
    o
    ws
    _count=
    1 
    &
     s
    kip_f
    rs
    _
    ro
    w ) 
    / 
    m
    pt
    y ou
    pu                  
    in
    t[    int[rows
    _c    un    int[]
     l     n    ow
    s
    count*co
    ls
    _
    ou     int c
    ur     =
     
    0;
     
     
     
     
    o
    (int
     r    =0
    ;
     v1[row_
    s
    t
    a
    t
    !=0
    x0        {
  
      
     
     

    th
        int row_lengt           row
    length=0; 
    v
    [row_start
    +
    ow_length]
    =
    _
    lf    ngth++);
 
     
     
             
     
       
      /
    /
     
    d
    ter
    m
    ine cols
     
    oun
    t,
     p    nt    
 
     
      
     
       
     
      
    int cur_c
    ls        for(in
    t 
    id    _l
    e
    gt
    h
    ; i
    d
    x+
    +)
 
          v1[ro
    w_    x]    tor )
    
     
     
            c
    u
    r_c
    ls_
    c
    n
    t
    +;

     
            
     
     if
    ( 
    co    r_
    c
    ls
    _
    cnt
     
    )

        
          ew alglib.
    al
    gl    io
    n
    "read_csv:
     n
    o
    -r
    ctangular cont
    nts, rows have different s          
             
     
     
    / store
    o
    fse
    s a
    n
    d lengths 
    o
    f the fiel
    d
    s
       
     
    i
    t cur_o
    f
     = 
    ;
 
     
              
    i
    nt cur_col
    _
    id       
           for(
    n
     
    id    <ro
    w
    _le
    gth+1; id
    x
    +
    +
    
 
     
             
     
      
      i
    f
     v    ar    rator || v1[row_start+id       
              
     {       
     
         offse
    t
    s
    [
    ur
    _
    row_idx*c
    o
    ls_count+c
    u
    r_
    col_
    i
    x] = row_s
    ta
    r
    t

         lengths[cur_row_idx*cols_count+cur_col_idx]     fs;
                
     
     
          th 
    =
     id
    -cu
    r
    _
    o
    fs>
    m
    ax_length 
    ?
    idx
    -c
    ur    th
    ;
      
     
             
     
       
     
      
     cur_offs
    =            cur_c
    ol
    _i      
     
          }
  
      
            
   
           row 
    tar
    
     
     
          cur_row_i
    d
    x++;
            row_start = row_start+row_length+1;
        }

     
     

    // Convert
        //
        int row0 = sk     ? 
     : 0;
  
     
     
          ows
    count;
    
     
     
    Sy    zat
    i
    on.
    ult
    u
    r
    e
    nfo
     
    culture = 
    S
    y
    s
    em.
    Gl
    ob    eI
    n
    o.
    C
    reateSpec
    i
    fic
    C
    ul
    ture("");
    //
    in
    v
    ariant cu
    l
    tur
    e
    
 
        
          bl    unt];
 
     
          algli
    b
    .AE_CRITIC
    A
    L_ASSERT(cu
    l
    u
    e.NumberF
    o
    rmat.Num
    be    .");
  
     
         for(in
    t
     ridx=row0
    ;
     ridx<row1;
     
    i
    x++
    )
    
       
          idx<cols_c
    u
    t; 
    c
    idx++)
 
     
              
    

       
     
            
     
    int field_
    le    ls_count
    c
    dx]
    ;
    

          eld_offs = 
    of
    fs    u

    
                // r    full stop
 
      
          or(int id
    =
    ; idx<fie
    l
    d_len; idx
    +
    +
    )
     

    fie    idx]==b_com              
        
     
    1[field_offs+i
    x
     
     
    _
    fu       
        
     
         
    
            // c
    o
    nvert
       
     
            str
    ng s_va
     
     Syste
    m
    .Text.Encodin
    g
    .ASCII.GetS
    t
    ring(v1, field_offs, 
    f
    ie
    l
    d_len);
                   d_val;
     
       
          
     
       D
    o
    uble
    .
    ryParse(s_
    v
    al    .Globa
    l
    ization.NumberStyl
    e
    s.Float
    ,
     culture, ou
    t
     d_val);
             
      
     ma
    t
    ri    ow0
    ,
    cid
    ] = 
    d
    _val
    ;
        
     
        
     
     }
 
      
     }


    /********************************************************************
    serializer object (should not be used directly)
    ********************************************************************/
    public class serializer
    {
        enum SMODE
        {
            DEFAULT,
            ALLOC,
            TO_STRING,
            FROM_STRING,
            TO_STREAM,
            FROM_STREAM
        };

        private const int SER_ENTRIES_PER_ROW = 5;
        private const int SER_ENTRY_LENGTH = 11;

        private SMODE mode;
        private int entries_needed;
        private int entries_saved;
        private int bytes_asked;
        private int bytes_written;
        private int bytes_read;
        private char[] out_str;
        private char[] in_str;
        private System.IO.Stream io_stream;

        // local temporaries
        private char[] entry_buf_char;
        private byte[] entry_buf_byte;

        public serializer()
        
                      mode
         

        eeded         =         0;
 
        ked          0
        
   
           ent        ry        _
        buf_
        b
        yte = ne        w         b
        yte[S
        E
        R_ENT        RY        _LEN
        G
        TH
        +
        ];
       
                            ent        ry        _buf_
        c
        ha        _ENTRY
        LENGT
        H+2];
        }

        public void clear_buffers()
        {
                           
         
        out_str = n        ul        l
        ;
        
                           in_
        s
        r =         n        ll;
 
         
         
        = n        ul        l;

         
            
         
          }

        public void alloc_start()
        
                  /********************************************************************
        serializer object 

        public void alloc_entry()
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        f
        (
         
        m
        o
        d
        e
        !
        =
        S
        M
        O
        D
        E
        .
        A
        L
        L
        O
        C
         
        )
        

         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
        t
        h
        r
        o
        w         alglib
        algli
        exception("        IB: internal e
        ror du        in         (un)se
        ri        lizat
        io        ");
     
                      entries
        _n        eded++;
 
                      }

        public void alloc_byte_array(byte[] a)
         {
         
                   if( mo
        e!=SM
        DE.
        LLOC )
         
         
          
         throw new alglib
        algli
        exce
        ption("ALGLIB: in
        ern
        l error during
         (un)serializatio
        ");
                    i
        nt n = ap.len(a);
           
                n =
         n/8 + (n%8>0 ? 1
        : 0
        ;
           
         entries_needed +
         1+
        ;
        
        }

        private int get_alloc_size()
        {
            
         
         
             i
        nt rows, lastrows
        ze, re
        s
        ul
        t
        ;
    
               
 
                   // check and change mode
           
        if( 
        m
        o
        e!=SMODE.ALLOC
         )
              
         thr
        o
        w
        new alglib.alg
        lbexception("ALG
        IB: intern
        a
        l
        eria
            

         
         
         
        no 
        n
        r
        egenera        te ca        se        )
 
         
           
                    i
        f
        (         en        tries_needed        ==        0 )        
          
         
                                     byt
        s
        ask
        d = 
        4
        ; /* a pai         of ch        a
        r
        s
         
        for \r\n, oe for space, on
         for
        dot */ 
     
         
                  r
        ed;
   
         
                      
        
                      
         
          //
         
        r
        te c
        a
         rows = entries_
        eede
        /SER_ENTRIE
        S
        _
        lastrowsize = 
        E
        _
        EN        W;
        
         
         
        if        eded
        S
        R_ENT
        R
        IES_P
        ER_ROW!=0 )            {
 
            
                 la
        s
        trowsize = 
        PE        R_        R
        
                                                                                r        ow        s+        +;        
                                        
         
        la        te         r        es        u
        t s
        ze
                          result  =
         
        ((rows-1)*SER_ENTRIE        _PE
        _ROW+l
        s
        tr
        o
        wsi        ze)*SER_E        NTR
        Y_L
        a size *        /
     
          
         
         =  (rows-1)*(SE
        _ENT
        IES_PER_ROW-1)+(
        l
        astr
        o
        w
        i
        ze         
        sy
        m
        ols        *
        /

                     
                     r
        s
             
           
                                                       
         
                            /* n        w
        ine s
        mbols *        

          
         
                 resu        t +=                    
         
         
          
         
           
         
         
         
         
         
                   
         
         
         
         
         
         
         
         
        /
         
        ra        l
        ng        d
            bytes_aske
         =        e
        su        t
           return result;
           
            }

        public void sstart_str()
        {
  
         
                i        t 
        a
        loc        si        ze         =         g

         
            // clear i
        ff
        es         w        hi        h
         m
        ay ho
        l
        d poin        e
        ory
                               
           // 
        N
        OTE:         it also hel
        p
        s us         o 
        a
        oid err        or        se        are 
        ea
        uf        e)                 
            
         
        an        d         c
        ange mode
    
          
         
         
        )
                                 
                  th        row new alglib.alglibexception("ALGLIB: internal error during (un)
                    
         
        T

          
        th        r 
        re        pi            
         
             out_        tr =         e
        w char[allo        cs        ie            entries
        s
        d          0        ;
            b
        y
        
 
         
             }

        public void sstart_stream(System.IO.Stream o_stream)
        {           
                
         
        /outp         y ho
        ld
         
            
            /         
        OT        : i         us to
        v
         
        e
        rror
        s
         
        w
        h
        en data are wri        ten 
        t
        o         nc        orr        ec        t loc
        a
        t
        ion
                         _
        uffe
        s
        (
          
         
          //
         
        c
        h
        e
        c
        k a        d cha        ge mode
   
         
         
         
         
                             if(         mo        de        =S        MO
        D
        E
        .
        A
                    t        row
        ne        w
        xc        p
        /* new
ine s
mbols */
              
        io
        s
        tream = o_stream;
        }

        public void ustart_str(string s)
        
                       
         /        r input/out        t
        buf        fersw         may h
        ld poi
        n
        eded memory
    
            
          // NOTE:
         
        it also hel
        errr        s         hen dat
         
        r

        on
                  c        le
        r_buff        rs        ()
        
                     
                          

         and         c        han
        g
         m
        de
 
                               
          
        f(m        od        !=S
        ODE.DE
        AULT
        )
  
           
        ib.        lglibe
        x
        c
        e
        dur
        ng        (un)
        eria
        D
             
           
        
     
         
              in_str = 
        s
        .ToCharArray();
            bytes_read = 0;
        }

        public void ustart_stream(System.IO.Stream i_stream)
        {

                    
            
         
         // clear
         
        in        uffers w        ic         
        a
         
        ho        to         
        
           // N
        TE: 
        t also helps 
        u
        s to a
        v
        oi
        d
         error
         when da
        ta are writ
         
              
        clear_b
        ffers
        );

                     

        ange        mod
        e
          
            
            i
        ( 
        ode        S
        .D        EFAUL        T
                              
            
           
        throw nw         a        l
        lib.algli
        exce        pt        io        n("A        nal err        r dur        ng         
          
                                      mo        d
         = 
        MODE.F
        OM_S
         i
        o
        stre
        am
         = i        _s        tr        ea        m;
        }

        private void serialize_value(bool v0, int v1, double v2, ulong v3, int val_idx)
        {
             
         
            // p
        repare serilization
      
            
        char[] arr
        _
        out = 
        u
        l

        _out = 0;
                    f( mode
        =SMOD
        .TO
        ST        IN
         )
                      {

              

        t = out_
        ;

            
                    ut = 
        ytes
        wri
        
                    f( m        de==SMODE
        .
        T
           
                               r_        ut
        ;
        

            
          
                     
         
                   nt_ou         
        el
        s
        e
                                   h        ew a        gl
        b
        .a
        lg        ibex(         
              
                  
          
                  /
        /
         
        se                if
         
        a
        l_idx==0 )
               
        ool2
        tr(  v0, arr_
        o
        ut, re
        f
         c
        n
        t_out)
        
       
             else i
                
            i
        n
        t2str(
          v1, a
        r_out
        e
        t_ou
        );
     
          

                       
         
         
         dou
        le2st(        v2        ,
        ar
        _o        ut        , r        ef        cnt_ou        ;
  
                     
           
        lse 
              ul        ng2str         
        v
         els
        
            
        w         e
        lgl
        ib
        .g        l
        ibexcep
        l err
        r 
        uri        g s
        e
        rializ        tion");
 
         
                  entries_saved++;
    
        _sav        %
        _ENT
        R
        IE        _PER=                                         {
          
                
            arr_outcnt_out] = ' ';

            
                  cnt_o
        u
        t++;
          
         
           
          
         
        }
    
          
         
           el
        e

         
           
              {
        
                   [cnt_out+0] = '\r';
             rr_o
        u
        t
        cnt_out
        1
         = '
        \n           
           cnt_
        u
        +
        =2          
        }
            
          
             
         
        
        
                  ce        f( mode
        =
        MODE.TO
        _S            {
 
         
                    b
        yt         c            
          
         
           r
        et
        urn;

         
                 
         }         e        ODE.TO_
        T
        EAM )
        
                      for
        i
        t
         k        t;                     uf_by
        e[k
         = (by
        t
        e)entry_buf_cha
        r
        [k];
                io_stream.Write(entry_bu
        f
        _

                 retu          
         
        }
     
          
         
                        th
        r
         n
        e
         alglib
        .
        lgl
        bexcept
        i
        on        tern
        l 
        e
        ror dur
        in
        g
        se               
        }

        private void unstream_entry_char()
        {
           
               
         
        i
        OM_
        row new a
        ll        i:        nal
        n
        eri        liza        tio        n
        ");
                i        t
        c;
          
             
        fo        r(        ;;)
       
           
             c = io_s
        tr
        e
              
                    if(         c        <0 )
      
          
         
                  w
        xceptio
        n
        ("ALGLI
        B
         
        nte
        r
        serial        iz        a
        ti
        o
         
        !='        t
        c=               
         
           brea
        k
        ;
        

         
            
                   entry        _b        uf        char[0]          (        a
        )c        ;
        

          
        k=1;         <S        R_        E
        N
        T
        )

         = io_stream.Rea          
         
                               entr
        y
        _bu        f_char[
        ]          
        <0         || c==' ' |
         
        =='\t' 
        |
         )        
             
         
        ro        .alg
        ib
        e
        cept
        io
        n("AL
        G
        LIB:        in        ern
        l
        un        
                                
         
        }
        

         
         
               
         
        e
        nt
        ry        LENGTH] = (ch        r
        )
        0;         
         
                    }

        public void serialize_bool(bool v)
        {
        

                                    e        , 0, 0
        );
        }

        public void serialize_int(int v)
        {        
                                  eria        ize_valu        e(        fa
        l
        se, v, 0, 0, 1);                              }

        public void serialize_double(double v)
        {
 
                  serialize
        _
        value(false
                  }

        public void serialize_ulong(ulong v)
        {
 
         
                  serialia        al        e, 0, 0, v, 3        );
        }

        public void serialize_byte_array(byte[] v)
        {
         
                                 
          
         
         
        

         
         
        ength               in        t         n
         = ap.l        e
        
                     ize_int(n)        ;
          
          
           /        i
        ne
         ent
        i
        t ent        ri        e
        _s        nk_size>0 ? 1 
        :
         
        0
        ;
         
                     
         
         
        e
        i
        d
        x
        0
        ;
         eidx<        en        ti        et        x
        +)
      
         
             {
 
         
         
         
        n = n        -e        idx*chunk
        _s        z
        ;
         
            
         
         
         
        >
        c
        un
        _
        si
        ze 
         
        _s
        ize          e;         
        ng 
        mp 
         0x0;

         
                                             f        or(        i
        n
        t i=        0;         i<
        e
        en; i++        
                       t
        mp 
        g
        i]        )<<        (8*i));
   
         
                    seri
        a
        i
        e
        _ulon        g(        t
        m
            }
        }

        public bool unserialize_bool()
                  if( mo
        d
        e
        =
        S
        M
        D
        E
        F
        R
        M_        S
        TRING )
               ret
        rn s
        r2bool(in_str
        ,
         re
         
        bytes_read);         if( mode==SMOD
        E
        .FR        OM        _S
        T
        E
        A
         
        )
         
         
         
         
                                 u
        stre
        m_entry_char();

         
              
         
               int 
                                     retu
        r
        n stro        ybuf_char, ref d
        mmy)
        
            }

         
             
         
            throw n
        bexception("ALG
        L
        IB: i
        n
        e
        r
        a
        l
        e
        r
        o
        r
         during (unserialization")
        
   
            }

        public int unserialize_int()
        
                      n s
        r2        n
        (i
        n
        _s
        ad);
        
         
         
         
         

        AM )
                           {
                   
              r        ntry_
        h
        r
        (
        )
        ;
        
         
         
         
                  i
        du        m
        re        tu        rn         s        r2        in        (ent
        r
        y_buf_char, r
        e
         dumm        )
        ;
         
        a
        g
        i
        b
        .alg
        l
        ibexce        ption        "
        un        )s        ria        iz        ati        on
                     }

        public double unserialize_double()
            
         
                             
         
         
        i
        f
         
        mo        de        =S
        M
        D
        E.
        FR                    
        rs        r
        2
        d
        ou
        b
        l
        e
        (
        i
        n
        _
        );
                                          if( 
        m
        od        eS        _STREAM )
           {
   
            
               unstream_
        e
        nt          
         
                             in        t         um        my        =         0;                                             
         r        (ent        y_
        uf        char, 
        r
        ef dumm        y)        
 
               }
 
         
                  w 
        n
        w al
        gl
        ib.al        gl        i
        bexcept        io        ("        A
        B
        ur        at        on");                }

        public ulong unserialize_ulong()
                                 
        f( mode=
        =
        SMODE.FROM_STR
        I
        G )
                     
         
         
         ref 
        ys                  
        i
        f( mo        de        ==
        S
        OD        E.        RO        M_        TR        EA         )        
                                  {
         
          
         
                    u
        ns
        car();
         
           
          int dummy = 0
        ;
        

        ummy);
                                
                  }
                    n
        e
        w
        nt
        rn        i
        on");
        }

        public byte[] unserialize_byte_array()
        {
               
         
                    in        t chunk_si
        z
         =         8             
                   
        rr        y         en        gt        h
        , al        lo        cate output
        

                  er
        i
        alize_int();
           byte[] result 
         new b
        te[n];
           
         
        

        tr        i
        ount
        
 
                                       
                   int entrie
        _
        size +
        (n%c        hu        nk        _si        ze        >0         ?         1         :         0        )         o
        r(        ei
        d<        en        tri
        es
        _coun
        t
        ; eidx++)
 
                   
        en = n-eid        x*        chunk_siz
        e
        ;
        

        n =
        elen>
        h
        n
        k
         : ele
        ;
        
         
                       long tm
        p=         u        ns
        riali
        z
        e
         
        or(in         i=        ;
        i<e        len        ; 
        i
        ++)
                    
         
                    s        x*chu
        k
        _s
        i
        ze+i] = unche
        cked((byte)(tp>>(8*i)));
   
             
          }
            

         
         
         
         
            
                   r        eturn
         
        result;
                    
          }

        public void stop()
        {                 
         
         
        DE        .
        T
        _STR
        ING         )           
         
                {
 
                  o
         =         ';            
         
         
         
        +;

             
         
                            SMOD
        E
        .
                       
                                       //        beca
        se in
        ut sr         b
        e from pre-3.1 serializer,
 
            
         
         
               // which does n
        o
        t include t
        do 
        ot test
                    
         
         
        of "
        " symbo        l
         Anyway,
        becauss           
         
         
          // i        s         not strea
        m
        ,
         w        e to
         
        r
        ad ALL
        ili
        g         ym
        b
        o
        l
        s
                        
           
              }                      
                  f
        (
         
        mode==SMOD
        E
        .
        O
        S
        R
        A
        M
         )         {
         
         
           
            
         
         
         
          i        o
        _
        stream        .Wr        iteByt        e(        (
        yte)
        '.
        '
         
          
         
         
         
          }

         
                           i        fd        D
        .F        OM_S
        TR        AM        )
                   
                    

        (;;)

                    
         
                        {
                   
         i
        o
        _s
        r
        e
        a
        m.        e
        a
        dByt
        e)        ;
          
         
        =' ' |
        |
         c==
        '
        \t'         |         c==        '\        n'
         
        |
        |
        c
        ='\r'         )
  
         
         
            
         
         
           
         
         
         
         
         
         
         
         
         
         
         
              
              
         
                        
         thr
        w ne
        w
         alglib.algl        "A
        L
        LIB:
         i
        ntern
        a
        l error d
        ri        za               
         
        }
           
         
         
         re
        tu        }
           
         t
        hr        glibex
        ce        B:        ro
        r
        duri
        ng
         unse
        r
        ialization"
        ;
        }

        public string get_string()
        {
          
            
           
         
        if( 
        ode!=SMODE
        .

               throw new         a        l
        lib.alg
        ix        io
        AL
        LIB:
        za
        io        ");
                   
        re        urn new
        string

        ritten);
                }


        /************************************************************************
        This function converts six-bit value (from 0 to 63)  to  character  (only
        digits, lowercase and uppercase letters, minus and underscore are used).

        If v is negative or greater than 63, this function returns '?'.
        ************************************************************************/
        private static char[] _sixbits2char_tbl = new char[64]{
            'D',            'E',             'F            ,
                'G', 'H'            ,             I', '            ',             'K',             'L            ', 'M', 'N            ,
                'O', 
             
                                   'W', 'X', '
            'b            ', 'c', 'd', 
                            'e', 'f', 'g', 'h', 'i', '            j'             'k',             'l            , 
                                                    m'            o,            ', 'r', 's', 't', 
                    '
            , '
             'z', '-',             '_' };

        private static char sixbits2char(int v)
        {f        >63        )
 
           
        urn '?
        ;
                r        rn _si
        x
        bits2char_t[v];
        }

        /************************************************************************
        This function converts character to six-bit value (from 0 to 63).

        This function is inverse of ae_sixbits2char()
        If c is not correct character, this function returns -1.
        ************************************************************************/
        private static int[] _char2sixbits_tbl = new int[128] {
            -1, -1               -1, -1, -1, -            1,
            -1, -1, -1, -1, -1, -1, -               -
             -1, -1,
                      -1, -1,
            1, -1,
            -1, -1, -1, -1, -1, 
                   0,  1,  2,  3,  4,  5,  6,  7,
 
             -            1, -             -1, -1, -1,
                -1, 10, 11, 12, 13, 14, 15, 16,
                    18, 19, 20, 21, 22, 23, 24,
   
             25, 26             27, 28, 29, 30, 31, 32,
                                    33, 34,             -,            /************************************************************************
            This function converts character to six-bit value (from 0 to 63).
    
            This function is inverse;

        private static int char2sixbits(char c)
        {
        

            
              re
        urn (c>
        0
         
        && c<127) ?
         
        _
        c
        h
        a
        r
        2
        s
        i
        x
        b
        i
        t
        s
        _
        t
        b
        l
        [
        c
        ]
         
        :
         
        -
        1
        ;
        

         
         
         
         
         
         
         
         
        }

        /************************************************************************
        This function converts three bytes (24 bits) to four six-bit values 
        (24 bits again).

        src         array
        src_offs    offset of three-bytes chunk
        dst         array for ints
        dst_offs    offset of four-ints chunk
        ************************************************************************/
        private static void threebytes2foursixbits(byte[] src, int src_offs, int[] dst, int dst_offs)
        {
 
         
          
         
          
         
         d
        s
        [d
        s
        _o
        f
        s+
        0
         =
                  +0
        ]
        & 
        0
        3F
        ;
         
         
         
         
         
         
         
         
         
        d
        s
        t
        ds
        t_        r
        c
        [
        rc
        _
        ff
        s
        0]
        >
        6)
         
         (
        (
        rc
        [
        rc
        _o        <<
        2
        ;

         
          
         
          
         
          
        d
        t[
        d
        t_
        o
        fs
        +2        _o
        f
        s+
        1
        >>
        4
         |
         
        (s
        r
        [s
        r
        _o
        f
        s+
        2]          
         
          
         
          
         
        d
        s
        t
        d
        s
        t
        o
        f
        f
        +
        3
        ]
        =
         
        s
        rc[src_offs+2]>>2
        
     
          }

        /************************************************************************
        This function converts four six-bit values (24 bits) to three bytes
        (24 bits again).

        src         pointer to four ints
        src_offs    offset of the chunk
        dst         pointer to three bytes
        dst_offs    offset of the chunk
        ************************************************************************/
        private static void foursixbits2threebytes(int[] src, int src_offs, byte[] dst, int dst_offs)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        d
        s
        t
        [
        d
        s
        t
        _
        o
        f
        f
        s
        +
        0
        ]
         =      (byte)(sr
        [src_o
        fs+0
         | ((src[src_offs+1]&0
        x
        03)<
        <
        6
        );

         
           
              ds
        t
        dst
        _
        o
        fs+
        1
         = 
        byte)((s
        rc[src_offs
        _o        ff        +
        2]        &0        0F)        <<        )
        );        
                      
         
         dst[dst
        _
        of        fs        2         =         byt        e
        |          (        sr        [sr        c_offs
        +
        3
        ]
        <
        )
        );
                                       }

        /************************************************************************
        This function serializes boolean value into buffer

        v           boolean value to be serialized
        buf         buffer, at least 11 characters wide
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.
        ************************************************************************/
        private static void bool2str(bool v, char[] buf, ref int offs)
                 
        ar c =
        v 
         '1
         : '0';
       
         
         
         
         
         
        i
        n
        t
         
        i
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        f
        o
        r
        (
        i
        =
        0
        ;
         
        i
        <
        S
        E
        R
        _
        E
        N
        T
        R
        Y
        _
        L
        E
        N
        G
        T
        H
        ;
         
        i
        +
        +
        )
        

         
         
         
         
         
         
         
         
         
         
         
         
         
           buf[offs+i] = 
        ;
    
            
          offs += SER_ENTRY_LE
        N
        GTH
        ;
        

           
         
          }

        /************************************************************************
        This function unserializes boolean value from buffer

        buf         buffer which contains value; leading spaces/tabs/newlines are 
                    ignored, traling spaces/tabs/newlines are treated as  end  of
                    the boolean value.
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.

        This function raises an error in case unexpected symbol is found
        ************************************************************************/
        private static bool str2bool(char[] buf, ref int offs)
        {
           
                bool was0, 
        as1;
        
          
         
         
        s
        t
        r
        i
        n
        g
         
        e
        m
        s
        g
         
        =
         
        "
        A
        L
        G
        L
        I
        B
        :
         
        u
        n
        a
        b
        l
        e
         
        t
        o
         
        r
        e
        a
        d
         
        b
        o
        o
        l
        e
        a
        n
         
        v
        a
        l
        u
        e
         
        f
        r
        o
        m
         
        s
        t
        r
        e
        a
        m
        "
        ;
        

         
         
         
                 
       
            wa
        0 = 
        alse;
  
         
            
         
         
         was
        1
         
         fa
        l
        e;

           
            
         
         |
         
        uf        o
        =='        '
        || 
        b
        uf        [o        f
        ==        '
        +;        
                                                            
        le        (         bu        f[        of        fs        ]!        ='         '         &        &         bu        f[        of        fs        ]!        ='        \t        '
         b        uf        [o        f
        buf
        [
        offs
        ]
        !
        =
         
         
            
          
             if( buf[        of        fs]=        =
                {
                    was0 = true;
                    offs++;
                    continue;
                }
                if( buf[offs]=='1' )
                {
                    was1 = true;
                    offs++;
                    continue;
                }
                throw new alglib.alglibexception(emsg);
            }
            if( (!was0) && (!was1) )
                throw new alglib.alglibexception(emsg);
            if( was0 && was1 )
                throw new alglib.alglibexception(emsg);
            return was1 ? true : false;
        }

        /************************************************************************
        This function serializes integer value into buffer

        v           integer value to be serialized
        buf         buffer, at least 11 characters wide 
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.

        This function raises an error in case unexpected symbol is found
        ************************************************************************/
        private static void int2str(int v, char[] buf, ref int offs)
        {
      
                     byte[] _by        erter.Ge                by        w           
         
         in
        t
        [] s
        i
        xb
        its
        =                       
         
        
   
                    //
         c
        op        s, sign 
        ex                  verti
        g t
         littl
        e
         endian order. 
        A
        ddit
        i
        on                  et
         
        t
        h
         byt
        e
        to
        z
        e
        ro i
        n
        or        
    
           
           // 
        c
        onversion to si
        x
        -bit
         
        re        
 
         
            
          
         //

                  stem.
        itC
        nverte
        r
        .IsLittleEndian
         
        )
  
         
                  ystem.
        rray
        R
        vers
        (
        bytes
        );
           c = v<0 ? (byte)0xFF : (byte)0x00;
            for(i=0; i<sizeof(int); i++)
                bytes[i] = _bytes[i];
            for(i=sizeof(int); i<8; i++)
                bytes[i] = c;
            bytes[8] = 0;
            
            //
            // convert to six-bit representation, output
            //
            // NOTE: last 12th element of sixbits is always zero, we do not output it
            //
            threebytes2foursixbits(bytes, 0, sixbits, 0);
            threebytes2foursixbits(bytes, 3, sixbits, 4);
            threebytes2foursixbits(bytes, 6
         sixbi
        s, 8
        ;      
         
         
 
         
         
            
         
         
        for
        (
        =0;
        i<S
        R_EN
        TRY_LENGTH;            
         
                  ] = 
        s
        i
        bits2c
        a
        (sixbi
        t
        s[i]);
     
         
              of
        f
        s
         +=
         
        S
        E
        R_        ;
  
         
         
          }

        /************************************************************************
        This function unserializes integer value from string

        buf         buffer which contains value; leading spaces/tabs/newlines are 
                    ignored, traling spaces/tabs/newlines are treated as  end  of
                    the integer value.
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.

        This function raises an error in case unexpected symbol is found
        ************************************************************************/
        private static int str2int(char[] buf, ref int offs)
              
         
         
        s
        r
        n
        g

        ble        eger value from stream";
            string e        "AL         to read integer value from stream (value does not fit into 32 bits)";
           []         w int[12];
           
         
        byte[
        ]
        b
        y
        es = ne
        w
        b
        y
        te             byte[] _bytes = n
        e
        w byt
        e
        s
        i
        eof(int
        )
        ;
        

                  t sixbitsread, i;
    
         
             
         
        by         c;
           
         
                   
          //         1         
        s
        ki         
        l
        ea        ing s        paces
    
         
         
          
         
        cod
        e
         six
        -
        b
        i
         i        gi        ts                                  
        // 3.         se        t
         
        t
        r
        a
        i
        zer        os        
           
                             // 4. convert
         
        dan 64-bit integer representation
            // 5. check that we fit into int
            // 6. convert to big endian representation, if needed
            //
            sixbitsread = 0;
            while( buf[offs]==' ' || buf[offs]=='\t' || buf[offs]=='\n' || buf[offs]=='\r' )
                offs++;
            while( buf[offs]!=' ' && buf[offs]!='\t' && buf[offs]!='\n' && buf[offs]!='\r' && buf[offs]!=0 )
            {
                int d;
                d = char2sixbits(buf[offs]);
                if( d<0 || sixbitsread>=SER_ENTRY_LENGTH )
                    throw new alglib.alglibexception(emsg);
                sixbits[sixbitsread] = d;
               
        sixbit
        rea
        ++;
   
         
            
         
         
           
         
        off
        ++;
            
                }
          ( sixb
        tsre
        d
                       throw new alglib.alglibexception(em
        sg           for
        i=sixbit
        r
        ; i<12; i++)
                sixbits[i] = 0;
            foursixbits2threebytes(sixb
        it         0)
        ;
        

               
         
         fo
        rsi
        x
        bi
        t
        s2        ixbi
        t
        s
         4, b
        t
        s, 
        );
 
         
         
         
                  xbit
        s
        2
        hreeby
        e
        (si
        bits
        ,
         8, by
        t
        es,
         
        6
        );         c 
         (bytes[siz
        e
        f
        (i        0)!=
         
        ?

                    i=sizeof(int); i<8; i++)
            if( bytes[i]!=c )
                        w alglib.alglibexception(emsg3264);         for(i=0; i<sizeof(int); i++)
                _bytes[i] = byt          
            if( !System.BitCon        tleEndian )
                System.Array.Reverse(_byte                   em.BitConve
        t
        r
        .T        s,0);
        

           
         
           }


        /************************************************************************
        This function serializes double value into buffer

        v           double value to be serialized
        buf         buffer, at least 11 characters wide 
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.
        ************************************************************************/
        private static void double2str(double v, char[] buf, ref int offs)
        {
        
            in
        t
         i;        
 
         
                  ] si        b
        i
        ts = ne         i        1
        ]
        ;
        
 
         
         
          
                   = new 
        b
        y
        t
        [
        ]
        ;
         //
            // han
        d
        le sp        eci
        a
         
        q
        antit
        i
        s
        
          
                               if        ( S        ys        tem.Double.I
        s
        NaN(v)         )        
          
         
                            {
        

         
         
        fs+0] = '.'        ;
                                            
         bu        [offs        +1         
        =
        'n'        ;
          
         
                   
                  s
        =
         'a';
        

                                         
           
         
         
         
        b
        f
        offs
        +
        3]
        n;        s+4
        ]
         
        =
         '_';

         
           
         
         
         
         
         
         
         
          
         b        ;

         
             
         
         
         
          
         
                       
           
             b
        u
        f[offs+7] = '_'
        ;
        
       
         
                  fs+
        8
        ]
         
        =
         
        _
        '
        ;
    
         
           
         
         
         
          
                  ';
   
         
         
         
         
             
         
         
        b
        u
          
         
         
              
         
         offs += SER
        _
        ENTRY_LENGTH;

                  urn;
 
         
             
         
            }
 
         
              
         
                  Double
        IsPosi
        t
        iveInfini        y(        )         )
        
      
         
             {
        

         
         
         
        b[offs+0] = '.';
                buf[offs+1] = 'p';
                buf[offs+2] = 'o';
                buf[offs+3] = 's';
                buf[offs+4] = 'i';
                buf[offs+5] = 'n';
                buf[offs+6] = 'f';
                buf[offs+7] = '_';
                buf[offs+8] = '_';
                buf[offs+9] = '_';
                buf[offs+10] = '_';
                offs += SER_ENTRY_LENGTH;
                return;
            }
            if( System.Double.IsNegativeInfinity(v)
        )
    
            
          {
      
         
              
         
         
        uf[o
        f
        f
        +0]
         
         '.
        ;
 
            
                  bu        'n'
        

                    b
        u
        f
        offs+2]
        =
        'e'
        
  
         
          
         
                  offs
        +
        3
         = 'g
        ;
           
            
         
         
         
                   ] =                  buf[offs+5] = 'n';
                    =
         
        f';
  
         
              
         
             
         
        b
        u
        [o        ;
        buf
        [
        offs
        +
        8
        ]
        =
        '_'
        ;
        buf
        [
        offs
        +
        9
        ]
        =
        '_'
        ;
        buf
        [
        offs
        +
        1
        0
         
         '_
        ';         of
        f
        s +=
         
        S
        E
        _
        NTR
        Y_           
         
            
        r
        e
        t
        r
        ;
 
                     
         
           

         
         
         
         
           
                  // 
        p
        roce
        s
        s
         
        e
        era
        l           /
        /
         1. 
        c
        o
        p
         
         to
         a           
         
            
         
         
        /
         
        . s
        et        o i
        n
         ord
        e
        r
         
        o
        sim
        pl        o s
        i
        x-bi
        t
         r
        e
        r
        sen
        ta         // 
        . 
        onvert to little
         e        )
    
                  co        -b
        i
         repre
        s
        entati
        o
        n
            //  
         
         
        (
        as        nt        lwa
        y
        s ze
        r
        o
        ,
        w
         do
         n           
         
            
         
         
        /
        

           
                  tes
         
        = Sy
        s
        t
        e
        .
        itC
        on        (do
        u
        ble)
        v
        )
        ;
         
           
                  .Bi
        t
        Conv
        e
        r
        t
        r
        IsL
        it           
         
            
         
         
         
        S
        ste
        m.        yte
        s
        );
 
         
         
         
         
           
                  f(d
        o
        uble
        )
        ;
         
        +
        )
 
                  es[
        i
        ] = 
        _
        b
        y
        e
        [i]
        ;
        i=s
        i
        zeof
        (
        d
        o
        b
        e);
         i           
         
            
         
        by
        t
        s
        i] 
        =         hree
        yt
        s2foursixbits(by
        te        );
   
                  by        it
        s
        bytes,
         
        3, six
        b
        its, 4);
         
         
         
         
        hr        si        six
        b
        its,
         
        8
        )
        

           
                  <SE
        R
        _ENT
        R
        Y
        _
        E
        GTH
        ;            
         
         buf
        [
        o
        f
        s
        i] 
        =         bit
        s
        [i])
        ;
        

         
         
           
                  NTR
        Y
        _LEN
        G
        T
        H
        

           
            }


        /************************************************************************
        This function serializes ulong value into buffer

        v           ulong value to be serialized
        buf         buffer, at least 11 characters wide 
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.
        ************************************************************************/
        private static void ulong2str(ulong v, char[] buf, ref int offs)
        {        
          
                   int i
        
 
             
         
         
        nt        [1
        ]
        ;

            
          
           b
        te        []        byte        s         =
         b        te[9        ];
  
                 

          
                             
         
          /        /
                                         /        / proce        ase:         
              
         /
         1. cop         v to 
        r
        ra
         of ch
        a

         // 2. set 9th byte to         ze         in or        de        r to si        mp        li        n to
        bi         re
        re
        se
        tation

          
               
        //
        3. co        nv        e
        t t        o         li        tt        e         dia         (i
         neede
        )

         
        o
        repr
        e
        s
        ntatio
         
                                                 /           (l        ast 12th
         
        element 
        o
        f
         si        xb        its
         i        s         al        w
        no
        t
        o
        utput 
        i
        t)
                                                    /        
                           byte[
         
        er        er.G        e
        t
        Bytes
        (
        (ulong)
        v
        );
                      
         
        tCo
        n
        v
        e
        r
        t
        r
        .
        IsLitt
        l
        eE        nd        ian )        
          
                   
        .Reve
        rs        e(        _
        ye        s)        ;
                             
         
                            ize
        o
        f
        (
        ul        on        g); i        ++        )
                             
         
                   
         
         
         
        b
        yt
        e
                                       f
        o(        i
        s
        iz        i<9; i        +)
                     
         
         by        tes
        [
        ]
         
         0;
   
         
         
         
         
        2foursixbits(bytes, 0,         s        xbits
        ,
        ;
        

                                 
         
        t
        h
        r
        s(bytes, 3, sixbits, 
        4
        );
  
         
         
         
                     t        hre
        e
        es        2
        , 6
        ,
         
        s
        i
        x
        i
        t
        s,         8)        ;
                                                   or(i        =
        ;
         i
        <
        ++)
                                                 
                   
        buf[offs+i] 
        =
         sixbit        s2        c
        h
        a
        r(        s
            
         o
        fs += SER        _E        NTRY_        LE        NG        TH;
        }

        /************************************************************************
        This function unserializes double value from string

        buf         buffer which contains value; leading spaces/tabs/newlines are 
                    ignored, traling spaces/tabs/newlines are treated as  end  of
                    the double value.
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.

        This function raises an error in case unexpected symbol is found
        ************************************************************************/
        private static double str2double(char[] buf, ref int offs)
        
                  t
        r
        ng e
        s
         =
        LG        LIB        un
        ble         to        ble value from stream";
            int[] sixbits = new int[1;        
  
                                b        te[]  

        [9]        

         
                       
         b
        te[] _
        ytes =
        n
        ew        yte[si        e
        )            in        t         si        bitsre

             
          
                                   /         
                
          /s        din        g         pa        ces
                     
                             uf[o
        f
         buf[
        o
        ffs        ]=        ='\t'         ||         
        buf[o
        ff        s]        =
        =
        ='\r        '         )
                                                               of        fs        ++;
   
         
         
                       /
        /
        
            
         
         
        spe
        c
        i
        a
        l
         
        a
        s
        es
                                            /
        /
        

         
          
         
        .'         )
                             
         
                                 
         
        strin
        g
         
         
        =
         
        n
        w
         s
        t
        _ENTRY        _L        N
        

         
        na
        n_______" 
        )
        
    
         
         
         
               {        
          
        of        fs         E        _
        E
        NTRY_
        L
        N
        G
        H;
    
                             
         
        ystem        .o        ublaN;
      
                   
                   }        
                              
         
         
         
                  pos
        i
        n
        f_        __         )        
           
         
           
         
            
         
         
                  of        s += SER_E        NT        RY        _
        L
        E
                    
          
        eturn System.Dou
        ble.PositivInfinity;
                }
                if( s==".neginf____" )
                {
                    offs += SER_ENTRY_LENGTH;
                    return System.Double.NegativeInfinity;
                }
                throw new alglib.alglibexception(emsg);
            }
            
            // 
            // General case:
            // 1. read and decode six-bit digits
            // 2. check that all 11 digits were read
            // 3. set last 12th digit to zero (needed for simplicity of conversion)
            // 4. convert to 8 bytes
            // 5. convert to big endian representation, if needed
            //
            sixbitsread = 0;
 
              
           whi
        e( buf[off
        s
        ]!='
         
        '
        && 
        b
        f[o
        fs]
        ='\t
        ' && buf[off        buf[of
        s]!=
        \
        ' && buf[offs]!=0 )
            {
               
         i           
         
         
            d =
        c
        ar2
        ixb
        i
        ts
        (
        bu            
         
         
             
        i
        ( d
        0 ||
         
        s
        i
        xb        _ENT
        R
        Y
        LENGTH
        )
           
            
         
              
         
            th
        r
        o
        w         lgl
        bexception(
        e
        s
        g

         = d              sixbitsread++;
            o             
         
        }
 
         
            
         
          
           
        f(
        six
        b
        itsr
        e
        ad
        !=SE
        _E
        TRY
        _
        LENG
        T
        H 
        )
  
          
           
         
            
         
         t
        hrow
        ne        xcep
        ti
        o

        NGT                foursixbits2thre        ts,        );
        

           
         
            
         
          
        fou
        si        yt        ytes, 
        )
        

           
              
         
        fou
        r
        ixbi
        t
        2threebytes(sixb
        i
        ts          
         
         
          
             for(i=0;
        i<        i+        byte
        [i
         = bytes[i];    
                  System
        BitCon
        v
        erter.
        I
        sLi
        tt                  Ar
        r
        y
        .R
        everse(_bytes
        ;                   onve
        te
        .ToDouble(_bytes
        ,0);
        }

        /************************************************************************
        This function unserializes ulong value from string

        buf         buffer which contains value; leading spaces/tabs/newlines are 
                    ignored, traling spaces/tabs/newlines are treated as  end  of
                    the ulong value.
        offs        offset in the buffer
        
        after return from this function, offs points to the char's past the value
        being read.

        This function raises an error in case unexpected symbol is found
        ************************************************************************/
        private static ulong str2ulong(char[] buf, ref int offs)
        {        
            stri
        n
        g
         e
        ms
         = 
        "
        ALG        I
        B
        : u        ab        e 
        to
        rea
        d
         ulo
        n
        g 
        v
        lu        m
        [] 
        i
        x
         
                                        yte[        ]          by        te        s =
         
        new 
        b
        y
        t
        e[         
        by        e
         =
        w         by        te[sizeof
        (u
        long)];
                                           n
                   
                    
           
           
  
         
                        // 
   
                                       /         
        p
        ac        /
         
          
         w        =' '
         |
        |
        '
        |
        |         uf[o        ff        s]=='        \r        ' )        
 
                                                     offs        ++        ;          
        //         
              
            //
         
        1. read and         dec        o         ts
 
         
         
         
                  eck that all 11 digits
         
        were re
        a
        

         
             
         
         
         
         
        digi         to zero (needed f
        o
        r simpl
        i
        i
        t
         of c
        o
        r
        / 4.         c        nvert         t         
        8 bytes
  
         
                                 
        /
         
        5
         conv
        e
        t
         
        t
        ese
        n
        t
        a
        t
        io        ,
         
        if nee
        d
        ed
   
         
         
         
          
                  sixbit        r
        ea        =
        0;
  
         
         
         
         
        !=
        '
        '
         && buf        offs]!=        '\        t' &&
         b        uf        [off        s]!='\n' &
         b        & buf[
        o
        ffs        ]!        0         )
        
               
         
            {
          
              
              
         
         d = char        six        i
        ts(buf[o
        f
        fs]);
          
         
         
                   if( d<0 || sixbitsread>=SER_ENTRY_LENGTH )
                    throw new alglib.alglibexception(emsg);
                sixbits[sixbitsread] = d;
                sixbitsread++;
                offs++;
            }
            if( sixbitsread!=SER_ENTRY_LENGTH )
                throw new alglib.alglibexception(emsg);
            sixbits[SER_ENTRY_LENGTH] = 0;
            foursixbits2threebytes(sixbits, 0, bytes, 0);
            foursixbits2threebytes(sixbits, 4, bytes, 3);
            foursixbits2threebytes(sixbits, 8, bytes, 6);
            for(i=0; i<sizeof(ulong); i++)
                _bytes[i] = bytes[i];        
            if( !System.BitConverter.IsLittl
        Endian
        )
   
                 
         
          Sy
        s
        t
        m.A
        r
        ay.
        eve
        se(_
        bytes);                 re
        urn 
        y
        tem.BitConverter.ToUInt64(_bytes,0);
        }
    }

    /*
     * Parts of alglib.smp class which are shared with GPL version of ALGLIB
     */
    public partial class smp
    {
#pragma warning disable 420
        public const int AE_LOCK_CYCLES = 512;
        public const int AE_LOCK_TESTS_BEFORE_YIELD = 16;

        /*
         * This variable is used to perform spin-wait loops in a platform-independent manner
         * (loops which should work same way on Mono and Microsoft NET). You SHOULD NEVER
         * change this field - it must be zero during all program life.
         */
        public static volatile int never_change_it = 0;

        /*************************************************************************
        Lock.

        This class provides lightweight spin lock
        *************************************************************************/
        public class ae_lock
        {
            public volatile int is_locked;
        }

        /********************************************************************
        Shared pool: data structure used to provide thread-safe access to pool
        of temporary variables.
        ********************************************************************/
        public class sharedpoolentry
        {
            public apobject obj;
            public sharedpoolentry next_entry;
        }

        public class shared_pool : apobject
        {
            /* lock object which protects pool */
            public ae_lock pool_lock;

            /* seed object (used to create new instances of temporaries) */
            public volatile apobject seed_object;

            /*
             * list of recycled OBJECTS:
             * 1. entries in this list store pointers to recycled objects
             * 2. every time we retrieve object, we retrieve first entry from this list,
             *    move it to recycled_entries and return its obj field to caller/
             */
            public volatile sharedpoolentry recycled_objects;

            /* 
             * list of recycled ENTRIES:
             * 1. this list holds entries which are not used to store recycled objects;
             *    every time recycled object is retrieved, its entry is moved to this list.
             * 2. every time object is recycled, we try to fetch entry for him from this list
             *    before allocating it with malloc()
             */
            public volatile sharedpoolentry recycled_entries;

            /* enumeration pointer, points to current recycled object*/
            public volatile sharedpoolentry enumeration_counter;

            /* constructor */
            public shared_pool()
            {
            

             
             
             
             
             
             
                          ae_ini
            _loc
            k
            ref 
            ool_lock)
            
   
              
                 }

            /* initializer - creation of empty pool */
            public override void init()
            {
            

             
             
             
             
             
             
             
             
             
             
             
             
             
             
                          ect = 
            ull;

                           r            objects = null;
    
                    
              r
            ecycled_entries = nu
            l;
            
               enumera
            ti            er            
     
                 
            }

            /* copy constructor (it is NOT thread-safe) */
            public override apobject make_copy()
            {
                
                  
             
               s
            ar
            dpoole
            try
            ptr, buf;
              
                       
             
            s
            hared_pool result = 
            ew share
            _pool();
                       
                
                /* create lock */
                ae_init_lock(ref result.pool_lock);
    
                /* copy seed object */
                if( seed_object!=null )
                    result.seed_object = seed_object.make_copy();
                
                /*
                 * copy recycled objects:
                 *
            1. copy 
            o temporary lis
             (objects are in
            srted to beginning, order is reversed)
                 * 2. copy temporary list to output list (order is restored back to normal)
                 */
                buf = null;
                for(ptr=recycled_objects; ptr!=null; ptr=ptr.next_entry)
                {
                    sharedpoolentry tmp = new sharedpoolentry();
                    tmp.obj =  ptr.obj.make_copy();
                    tmp.next_entr
             = buf;

                           
               buf = tmp;
  
                         }
                result.recycled_objects = null;
                for(ptr=buf; 
            tr!=null
            )
             
              {
               
                sharedpoolentry next_ptr = ptr.next_entry;
   
                       
             
                ptr.next_en
            ects;
                                               
                resu
            l
            s= ptr;
                    ptr = next_ptr;
                }
    
        
                   /
             rec
            cled
             
            entries are not
             any inform
            t
             */
            
             sult.recycled_en
            r
            es =
             
                                /* enumer
            t
            on             o
            u
            opying *            /
          
             
               r
            e
            ncounter = null;
    
                return result;
            }
        }


        /************************************************************************
        This function performs given number of spin-wait iterations
        ************************************************************************/
        public static void ae_spin_wait(int cnt)
        {
    
         
                    
         
        * these str
        an
        ge o
        er        _chang
        e
        _it are nec
        s
        ary to
    
         
                *
         
        p
        r
        /*
         * copy recycled objects:
         *
1. copy 
o temporary lis
(objects are in
serted to beginning, order is reversed)
         * 2. copy temporary list to output list (order is restored back to normal)
         */d         ne
        e
         be 
        tr          f
        o
        r(i
        =
        0; i<cnt; i++)
 
         
           
          
            
         
          i
        f
        ( n
        e
        ver_change
        _i                  _it--;
        }


        /************************************************************************
        This function causes the calling thread to relinquish the CPU. The thread
        is moved to the end of the queue and some other thread gets to run.
        ************************************************************************/
        public static void ae_yield()
            
         
               T        hrea
        d.Sleep(0);
        }

        /************************************************************************
        This function initializes ae_lock structure and sets lock in a free mode.
        ************************************************************************/
        public static void ae_init_lock(ref ae_lock obj)
        
         new a
        _lock(
        );         obj.is_locd = 0;
        }


        /************************************************************************
        This function acquires lock. In case lock is busy, we perform several
        iterations inside tight loop before trying again.
        ************************************************************************/
        public static void ae_acquire_lock(ae_lock obj)
        {
                        
         i
         
                   f          {

                   
        if        ead
        n
        g
        ge(ref obj.is_locked, 1, 0)==0 )
                    return;
                  n_
        w
        it(
        A
        E_LOCK_CYC
        ES           cnt++;
     
         
           
         
          
         
        /* spin wait, test condition which will ne
e
be 
true */}
        }


        /************************************************************************
        This function releases lock.
        ************************************************************************/
        public static void ae_release_lock(ae_lock obj)
        {
  
           
           
         
        Sys
        em.Threading.Inte
        locke
        .E
        cha
        ge(
        ef
        obj
        is_lo
        ked
         0);
             
          }


        /************************************************************************
        This function frees ae_lock structure.
        ************************************************************************/
        public static void ae_free_lock(ref ae_lock obj)
        {
        

         
         
         
         
         
               obj = n
        ll;
    
           }


        /************************************************************************
        This function returns True, if internal seed object was set.  It  returns
        False for un-seeded pool.

        dst                 destination pool (initialized by constructor function)

        NOTE: this function is NOT thread-safe. It does not acquire pool lock, so
              you should NOT call it when lock can be used by another thread.
        ************************************************************************/
        public static bool ae_shared_pool_is_initialized(shared_pool dst)
        {
   
           
             return
        ct!=null;
        }


        /************************************************************************
        This function sets internal seed object. All objects owned by the pool
        (current seed object, recycled objects) are automatically freed.

        dst                 destination pool (initialized by constructor function)
        seed_object         new seed object

        NOTE: this function is NOT thread-safe. It does not acquire pool lock, so
              you should NOT call it when lock can be used by another thread.
        ************************************************************************/
        public static void ae_shared_pool_set_seed(shared_pool dst, alglib.apobject seed_object)
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        d
        s
        t
        .
        s
        e
        e
        d
        _
        o
        b
        j
        e
        c
        t
         
        =
         
        s
        e
        e
        d
        _
        o
        b
        j
        e
        c
        t
        .
        m
        a
        k
        e
        _
        c
        o
        p
        y
        ();
          
         dst.rec
        cled_
        bjects 
         null;
  
                  d
        s
        t
        .
        e
        n
        u
        m
        e
        r
        a
        t
        i
        o
        n
        _
        c
        o
        u
        n
        t
        e
        r
         
        =
         
        n
        u
        l
        l
        ;
        

         
         
         
         
         
         
         
         
        }


        /************************************************************************
        This  function  retrieves  a  copy  of  the seed object from the pool and
        stores it to target variable.

        pool                pool
        obj                 target variable
        
        NOTE: this function IS thread-safe.  It  acquires  pool  lock  during its
              operation and can be used simultaneously from several threads.
        ************************************************************************/
        public static void ae_shared_pool_retrieve<T>(shared_pool pool, ref T obj) where T : alglib.apobject
        {
        

         
         
         
         
         
         
         
         
         
         
         
         
        a
        l
        g
        l
        ib.apobject new_
        bj;
  
            
            
            /* assert th
        a
        t pool was 
        eed
        ed */
     
        p.asset        oo
        l.
        seed
        _object!=nu, "ALGLIB: shared pool is not seeded, PoolRetrieve() failed");
            
            /* acquire lock */
            ae_acquire_lock(pool.pool_lock);
            
            /* try to reuse recycled objects */
            if( pool.recycled_objects!=null )
            {
                /* retrieve entry/object from list of recycled objects */
                sharedpoolentry result = pool.recycled_objects;
                pool.recycled_objects = pool.recycled_objects.next_entry;
                new_obj = result.obj;
                result.obj = null;
                
                /* move entry to list of recy
        led en
        ries
        */
                resu
        l
        t.next_entr
         = 
        p
        ol.rec
        y
        cled_ent
        ies;
      
                  p
        lt        ;
                                                                                        
                                        
         
         /        *         re        le        as        e         lo        ck         *        /
                                                                                        ae        _r        el        e
        a
        s
        ol_
        l
        ock)        
                   
        
   
         
         a        ss        ig        n         ob        je        ct         t        o         sm        ar        t         po        in        te        r         */        
                                                  
         
        bj         =         (        T)        n
           
                return;
            }
                
            /*
             * release lock; we do not need it anymore because
             * copy constructor does not modify source variable.
             */
            ae_release_lock(pool.pool_lock);
            
            /* create new object from seed */
            new_obj = pool.seed_object.make_copy();
                
            /* assign object to pointer and return */
            obj = (T)new_obj;
        }


        /************************************************************************
        This  function  recycles object owned by the source variable by moving it
        to internal storage of the shared pool.

        Source  variable  must  own  the  object,  i.e.  be  the only place where
        reference  to  object  is  stored.  After  call  to  this function source
        variable becomes NULL.

        pool                pool
        obj                 source variable

        NOTE: this function IS thread-safe.  It  acquires  pool  lock  during its
              operation and can be used simultaneously from several threads.
        ************************************************************************/
        public static void ae_shared_pool_recycle<T>(shared_pool pool, ref T obj) where T : alglib.apobject
        {
   
         
           
                  ry new
        _
        ent
        y
        
   
         
        /* move entry to list of recy
led en
ries
*/r        ct!=n        ul        l
        ,
         "ALGLIB:         ae        d         oo
        l
         is         no        t seeded,        Poo
        l
        ;           
         
        on-null */
                sert(obj        !=        nl         "AL        GL        IB:
         
        o
        ULL");
              
          
          
  
               
         
        /
        /

         
         
         
         
         
        ck);
 
                   
        /*
         * release lock; we do not need it anymore because
         * copy constructor does not modify source variable.
         */e        allocated entry
         
        */
 
         
                 
         
         
        ed_entries;
                pool.r        ies = n
        w
        entr
        y
        .next_entry
        ;
        
        
         
         
         
          {
                /*
                 *         ory
        f
        r
         
        n
        ew entr
        y.
               *
                 * NOTE: we release pool lock during allocation because new() may raise
                 *       exception and we do not want our pool to be left in the locked state.
                 */
                ae_release_lock(pool.pool_lock);
                new_entry = new sharedpoolentry();
                ae_acquire_lock(pool.pool_lock);
            }
            
            /* add object to the list of recycled objects */
            new_entry.obj = obj;
            new_entry.next_entry = pool.recycled_objects;
            pool.recycled_objects = new_entry;
            
            /* release lock object */
            ae_release_lock(pool.pool_lock);
            
            /* release source pointer */
      
             o
        j = 
        ull;
        }


        /************************************************************************
        This function clears internal list of  recycled  objects,  but  does  not
        change seed object managed by the pool.

        pool                pool

        NOTE: this function is NOT thread-safe. It does not acquire pool lock, so
              you should NOT call it when lock can be used by another thread.
        ************************************************************************/
        public static void ae_shared_pool_clear_recycled(shared_pool pool)
           
         
            
         
        pool.recycled_ob
        je
        cts 
         n         }


        /************************************************************************
        This function allows to enumerate recycled elements of the  shared  pool.
        It stores reference to the first recycled object in the smart pointer.

        IMPORTANT:
        * in case target variable owns non-NULL value, it is rewritten
        * recycled object IS NOT removed from pool
        * target variable DOES NOT become owner of the new value; you can use
          reference to recycled object, but you do not own it.
        * this function IS NOT thread-safe
        * you SHOULD NOT modify shared pool during enumeration (although you  can
          modify state of the objects retrieved from pool)
        * in case there is no recycled objects in the pool, NULL is stored to obj
        * in case pool is not seeded, NULL is stored to obj

        pool                pool
        obj                 reference
        ************************************************************************/
        public static void ae_shared_pool_first_recycled<T>(shared_pool pool, ref T obj) where T : alglib.apobject
        {
         
         
         
        

         
         
         
         
                /* mod
        fy inter
        al enu
        eration 
        ount
        r 
        
       
           pool
        .
        ume
        tion
        ounter = pool.recy
        led_
        bjects
        
      
          
          

            
              /* exit 
        
           if( p
        o
        l.en
        meration
        co
        nte
        ==null
         
        )
  
         
          
            
        {
 
               
            
         obj
         
         nu           
          retu
        n;

            
          
           }
            
           
          
        
   
          
             /*
        assign
         object to 
        s
        m
        a
        r
        t
         
        p
        o
        i
        n
        t
        e
        r
         
        *
        /
        

         
         
         
         
         
         
         
         
         
         
         
         
        o
        b
        j
         
        =
         
        (
        T
        )
        p
        o
        o
        l
        .
        e
        n
        u
        m
        e
        r
        a
        t
        i
        o
        n
        _
        c
        o
        u
        n
        t
        e
        r
        .
        o
        b
        j
        ;
        

         
         
         
             }


        /************************************************************************
        This function allows to enumerate recycled elements of the  shared  pool.
        It stores pointer to the next recycled object in the smart pointer.

        IMPORTANT:
        * in case target variable owns non-NULL value, it is rewritten
        * recycled object IS NOT removed from pool
        * target pointer DOES NOT become owner of the new value
        * this function IS NOT thread-safe
        * you SHOULD NOT modify shared pool during enumeration (although you  can
          modify state of the objects retrieved from pool)
        * in case there is no recycled objects left in the pool, NULL is stored.
        * in case pool is not seeded, NULL is stored.

        pool                pool
        obj                 target variable
        ************************************************************************/
        public static void ae_shared_pool_next_recycled<T>(shared_pool pool, ref T obj) where T : alglib.apobject
           
            /* e
        x
        i
        t
         
        o
        n
         
        e
        n
        d
         
        o
        f
         
        l
        i
        s
        t
         
        *
        /
        

         
         
         
         
         
         
         
         
         
         
         
         
        i
        f
        (
         
        p
        o
        o
        l
        .
        e
        n
        u
        m
        e
        r
        a
        t
        i
        o
        n
        _
        c
        o
        u
        n
        t
        e
        r
        =
        =
        n
        u
        l
        l
         
        )
        

                    {
  
              
            
         obj = null;
                
        r
        e
        t
        u
        rn;
       
            
        }
           
         
           
         
         
   
         
         
            /*
         
        modify internal en
                pool.enumeration_counter = pool.enumeration_counter.next_entry;
            
            /* exit on empty list */
            if( pool.enumeration_counter==null )
            {
                obj = null;
                return;
            }
            
            /* assign object to smart pointer */
            obj = (T)pool.enumeration_counter.obj;
        }


        /************************************************************************
        This function clears internal list of recycled objects and  seed  object.
        However, pool still can be used (after initialization with another seed).

        pool                pool
        state               ALGLIB environment state

        NOTE: this function is NOT thread-safe. It does not acquire pool lock, so
              you should NOT call it when lock can be used by another thread.
        ************************************************************************/
        public static void ae_shared_pool_reset(shared_pool pool)
        {
          

              
           
        pool.s
        ed_obj
        ct =
        null;

                   
        o
        ol.recyc
        ed_
        ject              
             
        oo
        .en
        meratio
        _counter 
         nul
        ;
  
              }
    }
}
#if ALGLIB_NO_FAST_KERNELS==false
#if ALGLIB_USE_SIMD && !_ALGLIB_ALREADY_DEFINED_SIMD_ALIASES
#define _ALGLIB_ALREADY_DEFINED_SIMD_ALIASES
using Sse2 = System.Runtime.Intrinsics.X86.Sse2;
using Avx2 = System.Runtime.Intrinsics.X86.Avx2;
using Fma = System.Runtime.Intrinsics.X86.Fma;
using Intrinsics = System.Runtime.Intrinsics;
#endif
#pragma warning disable 164
#pragma warning disable 219
public partial class alglib
{
#if ALGLIB_USE_SIMD
    private static int _ABLASF_KERNEL_SIZE1 = 8;
    private static int _ABLASF_KERNEL_SIZE2 = 8;
    private static int _ABLASF_KERNEL_SIZE3 = 8;
#endif

    /*************************************************************************
    ABLASF kernels
    *************************************************************************/
    public partial class ablasf
    {
#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rdot() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rdot(
            int n,
            double *A,
            double *B,
            out double R)
        {
            R = 0;
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_dot = Intrinsics.Vector256<double>.Zero;
                for(i = 0; i<head; i += 4)
                {
                    avx_dot = Fma.MultiplyAdd(
                                Avx2.LoadVector256(A+i),
                                Avx2.LoadVector256(B+i),
                                avx_dot
                                );
                }
                double *vdot = stackalloc double[4];
                Avx2.Store(vdot, avx_dot);
                for(i = head; i<n; i++)
                    vdot[0] += A[i]*B[i];
                R = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                return true;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_dot = Intrinsics.Vector256<double>.Zero;
                for(i = 0; i<head; i += 4)
                {
                    avx_dot = Avx2.Add(
                                Avx2.Multiply(
                                    Avx2.LoadVector256(A+i),
                                    Avx2.LoadVector256(B+i)
                                    ),
                                avx_dot
                                );
                }
                double *vdot = stackalloc double[4];
                Avx2.Store(vdot, avx_dot);
                for(i = head; i<n; i++)
                    vdot[0] += A[i]*B[i];
                R = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif
#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rdotv2()

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rdotv2(
            int n,
            double *A,
            out double R)
        {
            R = 0;
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_dot = Intrinsics.Vector256<double>.Zero;
                for(i = 0; i<head; i += 4)
                {
                    Intrinsics.Vector256<double> Ai = Avx2.LoadVector256(A+i);
                    avx_dot = Fma.MultiplyAdd(Ai, Ai, avx_dot);
                }
                double *vdot = stackalloc double[4];
                Avx2.Store(vdot, avx_dot);
                for(i = head; i<n; i++)
                    vdot[0] += A[i]*A[i];
                R = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                return true;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_dot = Intrinsics.Vector256<double>.Zero;
                for(i = 0; i<head; i += 4)
                {
                    Intrinsics.Vector256<double> Ai = Avx2.LoadVector256(A+i);
                    avx_dot = Avx2.Add(Avx2.Multiply(Ai, Ai), avx_dot);
                }
                double *vdot = stackalloc double[4];
                Avx2.Store(vdot, avx_dot);
                for(i = head; i<n; i++)
                    vdot[0] += A[i]*A[i];
                R = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

        /*************************************************************************
        Computes dot product (X,Y) for elements [0,N) of X[] and Y[]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process
            Y       -   array[N], vector to process

        RESULT:
            (X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rdotv(int n,
            double[] x,
            double[] y,
            alglib.xparams _params)
        {
            double result = 0;
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        double r;
                        if( try_rdot(n, py, px, out r) )
                            return r;
                    }
                }
#endif

            result = 0;
            for (i = 0; i <= n - 1; i++)
            {
                result = result + x[i] * y[i];
            }

            return result;
        }

        /*************************************************************************
        Computes dot product (X,A[i]) for elements [0,N) of vector X[] and row A[i,*]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process
            A       -   array[?,N], matrix to process
            I       -   row index

        RESULT:
            (X,Ai)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rdotvr(int n,
            double[] x,
            double[,] a,
            int i,
            alglib.xparams _params)
        {
            double result = 0;
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, pa = a)
                    {
                        double r;
                        if( try_rdot(n, px, pa+i*a.GetLength(1), out r) )
                            return r;
                    }
                }
#endif

            result = 0;
            for (j = 0; j <= n - 1; j++)
            {
                result = result + x[j] * a[i, j];
            }

            return result;
        }

        /*************************************************************************
        Computes dot product (X,A[i]) for rows A[ia,*] and B[ib,*]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process
            A       -   array[?,N], matrix to process
            I       -   row index

        RESULT:
            (X,Ai)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rdotrr(int n,
            double[,] a,
            int ia,
            double[,] b,
            int ib,
            alglib.xparams _params)
        {
            double result = 0;
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* pa = a, pb = b)
                    {
                        double r;
                        if( try_rdot(n, pa+ia*a.GetLength(1), pb+ib*b.GetLength(1), out r) )
                            return r;
                    }
                }
#endif

            result = 0;
            for (j = 0; j <= n - 1; j++)
            {
                result = result + a[ia, j] * b[ib, j];
            }

            return result;
        }

        /*************************************************************************
        Computes dot product (X,X) for elements [0,N) of X[]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process

        RESULT:
            (X,X)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rdotv2(int n,
            double[] x,
            alglib.xparams _params)
        {
            double result = 0;
            int i = 0;
            double v = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        double r;
                        if( try_rdotv2(n, px, out r) )
                            return r;
                    }
                }
#endif

            result = 0;
            for (i = 0; i <= n - 1; i++)
            {
                v = x[i];
                result = result + v * v;
            }

            return result;
        }

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for raddv() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_raddv(
            int n,
            double vSrc,
            double *Src,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_vsrc = Avx2.BroadcastScalarToVector256(&vSrc);
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Fma.MultiplyAdd(
                            Avx2.LoadVector256(Src+i),
                            avx_vsrc,
                            Avx2.LoadVector256(Dst+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] += vSrc*Src[i];
                return true;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_vsrc = Avx2.BroadcastScalarToVector256(&vSrc);
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Avx2.Add(
                            Avx2.Multiply(
                                Avx2.LoadVector256(Src+i),
                                avx_vsrc
                                ),
                            Avx2.LoadVector256(Dst+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] += vSrc*Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rmuladdv() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmuladdv(
            int n,
            double *Src0,
            double *Src1,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Fma.MultiplyAdd(
                            Avx2.LoadVector256(Src0+i),
                            Avx2.LoadVector256(Src1+i),
                            Avx2.LoadVector256(Dst+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] += Src0[i]*Src1[i];
                return true;
            }
            #endif // no-fma
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rmuladdv() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rnegmuladdv(
            int n,
            double *Src0,
            double *Src1,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Fma.MultiplyAddNegated(
                            Avx2.LoadVector256(Src0+i),
                            Avx2.LoadVector256(Src1+i),
                            Avx2.LoadVector256(Dst+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] -= Src0[i]*Src1[i];
                return true;
            }
            #endif // no-fma
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rcopymuladdv() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rcopymuladdv(
            int n,
            double *Src0,
            double *Src1,
            double *Src2,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Fma.MultiplyAdd(
                            Avx2.LoadVector256(Src0+i),
                            Avx2.LoadVector256(Src1+i),
                            Avx2.LoadVector256(Src2+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] = Src2[i]+Src0[i]*Src1[i];
                return true;
            }
            #endif // no-fma
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rcopymuladdv() and similar funcs

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rcopynegmuladdv(
            int n,
            double *Src0,
            double *Src1,
            double *Src2,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Fma.MultiplyAddNegated(
                            Avx2.LoadVector256(Src0+i),
                            Avx2.LoadVector256(Src1+i),
                            Avx2.LoadVector256(Src2+i)
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] = Src2[i]-Src0[i]*Src1[i];
                return true;
            }
            #endif // no-fma
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rmul()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmulv(
            int n,
            double vDst,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_vdst = Avx2.BroadcastScalarToVector256(&vDst);
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Avx2.Multiply(
                            Avx2.LoadVector256(Dst+i),
                            avx_vdst
                            )
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] *= vDst;
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rsqrt()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rsqrtv(
            int n,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                    Avx2.Store(Dst+i, Avx2.Sqrt(Avx2.LoadVector256(Dst+i)));
                for(i = head; i<n; i++)
                    Dst[i] = System.Math.Sqrt(Dst[i]);
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rcopy()

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rcopy(
            int n,
            double *Src,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Avx2.LoadVector256(Src+i)
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] = Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for icopy()

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_icopy(
            int n,
            int *Src,
            int *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n8 = n>>3;
                int head = n8<<3;
                for(i = 0; i<head; i += 8)
                {
                    Avx2.Store(
                        Dst+i,
                        Avx2.LoadVector256(Src+i)
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] = Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rcopymul()

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rcopymul(
            int n,
            double vSrc,
            double *Src,
            double *Dst)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_vsrc = Avx2.BroadcastScalarToVector256(&vSrc);
                for(i = 0; i<head; i += 4)
                {
                    Avx2.Store(
                        Dst+i,
                        Avx2.Multiply(
                            Avx2.LoadVector256(Src+i),
                            avx_vsrc)
                        );
                }
                for(i = head; i<n; i++)
                    Dst[i] = vSrc*Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rset()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rset(
            int n,
            double vDst,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                Intrinsics.Vector256<double> avx_vdst = Avx2.BroadcastScalarToVector256(&vDst);
                for(i = 0; i<head; i += 4)
                    Avx2.Store(Dst+i, avx_vdst);
                for(i = head; i<n; i++)
                    Dst[i] = vDst;
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for mergemul()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmergemul(
            int n,
            double *Src,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                    Avx2.Store(
                        Dst+i,
                        Avx2.Multiply(
                            Avx2.LoadVector256(Dst+i),
                            Avx2.LoadVector256(Src+i)
                            )
                        );
                for(i = head; i<n; i++)
                    Dst[i] *= Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for mergediv()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmergediv(
            int n,
            double *Src,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                    Avx2.Store(
                        Dst+i,
                        Avx2.Divide(
                            Avx2.LoadVector256(Dst+i),
                            Avx2.LoadVector256(Src+i)
                            )
                        );
                for(i = head; i<n; i++)
                    Dst[i] /= Src[i];
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for mergemax()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmergemax(
            int n,
            double *Src,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                    Avx2.Store(
                        Dst+i,
                        Avx2.Max(
                            Avx2.LoadVector256(Dst+i),
                            Avx2.LoadVector256(Src+i)
                            )
                        );
                for(i = head; i<n; i++)
                    Dst[i] = System.Math.Max(Dst[i],Src[i]);
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for mergemin()
        
          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rmergemin(
            int n,
            double *Src,
            double *Dst)
        {   
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            if( Avx2.IsSupported )
            {
                int i;
                int n4 = n>>2;
                int head = n4<<2;
                for(i = 0; i<head; i += 4)
                    Avx2.Store(
                        Dst+i,
                        Avx2.Min(
                            Avx2.LoadVector256(Dst+i),
                            Avx2.LoadVector256(Src+i)
                            )
                        );
                for(i = head; i<n; i++)
                    Dst[i] = System.Math.Min(Dst[i],Src[i]);
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

        /*************************************************************************
        Performs inplace addition of Y[] to X[]

        INPUT PARAMETERS:
            N       -   vector length
            Alpha   -   multiplier
            Y       -   array[N], vector to process
            X       -   array[N], vector to process

        RESULT:
            X := X + alpha*Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void raddv(int n,
            double alpha,
            double[] y,
            double[] x,
            alglib.xparams _params)
        {
            int i;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_raddv(n, alpha, py, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] + alpha * y[i];
            }
        }

        /*************************************************************************
        Performs inplace addition of Y[] to X[]

        INPUT PARAMETERS:
            N       -   vector length
            Alpha   -   multiplier
            Y       -   source vector
            OffsY   -   source offset
            X       -   destination vector
            OffsX   -   destination offset

        RESULT:
            X := X + alpha*Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void raddvx(int n,
            double alpha,
            double[] y,
            int offsy,
            double[] x,
            int offsx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_raddv(n, alpha, py+offsy, px+offsx) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[offsx + i] = x[offsx + i] + alpha * y[offsy + i];
            }
        }


        /*************************************************************************
        Performs inplace addition of vector Y[] to row X[]

        INPUT PARAMETERS:
            N       -   vector length
            Alpha   -   multiplier
            Y       -   vector to add
            X       -   target row RowIdx

        RESULT:
            X := X + alpha*Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void raddvr(int n,
            double alpha,
            double[] y,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_raddv(n, alpha, py, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = x[rowidx, i] + alpha * y[i];
            }
        }

        /*************************************************************************
        Performs inplace addition of Y[]*Z[] to X[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   array[N], vector to process
            Z       -   array[N], vector to process
            X       -   array[N], vector to process

        RESULT:
            X := X + Y*Z

          -- ALGLIB --
             Copyright 29.10.2021 by Bochkanov Sergey
        *************************************************************************/
        public static void rmuladdv(int n,
            double[] y,
            double[] z,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;
#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y, pz = z)
                    {
                        if( try_rmuladdv(n, py, pz, px) )
                            return;
                    }
                }
#endif
            for (i = 0; i <= n - 1; i++)
                x[i] += y[i] * z[i];
        }

        /*************************************************************************
        Performs inplace subtraction of Y[]*Z[] from X[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   array[N], vector to process
            Z       -   array[N], vector to process
            X       -   array[N], vector to process

        RESULT:
            X := X - Y*Z

          -- ALGLIB --
             Copyright 29.10.2021 by Bochkanov Sergey
        *************************************************************************/
        public static void rnegmuladdv(int n,
            double[] y,
            double[] z,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;
#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y, pz = z)
                    {
                        if( try_rnegmuladdv(n, py, pz, px) )
                            return;
                    }
                }
#endif
            for (i = 0; i <= n - 1; i++)
                x[i] -= y[i] * z[i];
        }

        /*************************************************************************
        Performs addition of Y[]*Z[] to X[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   array[N], vector to process
            Z       -   array[N], vector to process
            X       -   array[N], vector to process
            R       -   array[N], vector to process

        RESULT:
            R := X + Y*Z

          -- ALGLIB --
             Copyright 29.10.2021 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopymuladdv(int n,
            double[] y,
            double[] z,
            double[] x,
            double[] r,
            alglib.xparams _params)
        {
            int i = 0;
#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y, pz = z, pr = r)
                    {
                        if( try_rcopymuladdv(n, py, pz, px, pr) )
                            return;
                    }
                }
#endif
            for (i = 0; i <= n - 1; i++)
                r[i] = x[i] + y[i] * z[i];
        }

        /*************************************************************************
        Performs subtraction of Y[]*Z[] from X[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   array[N], vector to process
            Z       -   array[N], vector to process
            X       -   array[N], vector to process
            R       -   array[N], vector to process

        RESULT:
            R := X - Y*Z

          -- ALGLIB --
             Copyright 29.10.2021 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopynegmuladdv(int n,
            double[] y,
            double[] z,
            double[] x,
            double[] r,
            alglib.xparams _params)
        {
            int i = 0;
#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y, pz = z, pr = r)
                    {
                        if( try_rcopynegmuladdv(n, py, pz, px, pr) )
                            return;
                    }
                }
#endif
            for (i = 0; i <= n - 1; i++)
                r[i] = x[i] - y[i] * z[i];
        }

        /*************************************************************************
        Performs componentwise multiplication of vector X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target vector

        RESULT:
            X := componentwise(X*Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemulv(int n,
            double[] y,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemul(n, py, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] * y[i];
            }
        }

        /*************************************************************************
        Performs componentwise multiplication of row X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target row RowIdx

        RESULT:
            X := componentwise(X*Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemulvr(int n,
            double[] y,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemul(n, py, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = x[rowidx, i] * y[i];
            }
        }

        /*************************************************************************
        Performs componentwise multiplication of row X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target row RowIdx

        RESULT:
            X := componentwise(X*Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemulrv(int n,
            double[,] y,
            int rowidx,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemul(n, py+rowidx*y.GetLength(1), px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] * y[rowidx, i];
            }
        }


        /*************************************************************************
        Performs componentwise division of vector X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to divide by
            X       -   target vector

        RESULT:
            X := componentwise(X/Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergedivv(int n,
            double[] y,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergediv(n, py, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] / y[i];
            }
        }

        /*************************************************************************
        Performs componentwise division of row X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to divide by
            X       -   target row RowIdx

        RESULT:
            X := componentwise(X/Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergedivvr(int n,
            double[] y,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergediv(n, py, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = x[rowidx, i] / y[i];
            }
        }

        /*************************************************************************
        Performs componentwise division of row X[] by vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to divide by
            X       -   target row RowIdx

        RESULT:
            X := componentwise(X/Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergedivrv(int n,
            double[,] y,
            int rowidx,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergediv(n, py+rowidx*y.GetLength(1), px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] / y[rowidx, i];
            }
        }

        /*************************************************************************
        Performs componentwise max of vector X[] and vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target vector

        RESULT:
            X := componentwise_max(X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemaxv(int n,
            double[] y,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemax(n, py, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = System.Math.Max(x[i], y[i]);
            }
        }

        /*************************************************************************
        Performs componentwise max of row X[] and vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target row RowIdx

        RESULT:
            X := componentwise_max(X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemaxvr(int n,
            double[] y,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemax(n, py, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = System.Math.Max(x[rowidx, i], y[i]);
            }
        }

        /*************************************************************************
        Performs componentwise max of row X[I] and vector Y[] 

        INPUT PARAMETERS:
            N       -   vector length
            X       -   matrix, I-th row is source
            X       -   target row RowIdx

        RESULT:
            Y := componentwise_max(Y,X)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergemaxrv(int n,
            double[,] x,
            int rowidx,
            double[] y,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemax(n, px+rowidx*x.GetLength(1), py) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                y[i] = System.Math.Max(y[i], x[rowidx, i]);
            }
        }

        /*************************************************************************
        Performs componentwise max of vector X[] and vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target vector

        RESULT:
            X := componentwise_max(X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergeminv(int n,
            double[] y,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemin(n, py, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = System.Math.Min(x[i], y[i]);
            }
        }

        /*************************************************************************
        Performs componentwise max of row X[] and vector Y[]

        INPUT PARAMETERS:
            N       -   vector length
            Y       -   vector to multiply by
            X       -   target row RowIdx

        RESULT:
            X := componentwise_max(X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergeminvr(int n,
            double[] y,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemin(n, py, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = System.Math.Min(x[rowidx, i], y[i]);
            }
        }

        /*************************************************************************
        Performs componentwise max of row X[I] and vector Y[] 

        INPUT PARAMETERS:
            N       -   vector length
            X       -   matrix, I-th row is source
            X       -   target row RowIdx

        RESULT:
            X := componentwise_max(X,Y)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmergeminrv(int n,
            double[,] x,
            int rowidx,
            double[] y,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rmergemin(n, px+rowidx*x.GetLength(1), py) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                y[i] = System.Math.Min(y[i], x[rowidx, i]);
            }
        }

        /*************************************************************************
        Performs inplace addition of Y[RIdx,...] to X[]

        INPUT PARAMETERS:
            N       -   vector length
            Alpha   -   multiplier
            Y       -   array[?,N], matrix whose RIdx-th row is added
            RIdx    -   row index
            X       -   array[N], vector to process

        RESULT:
            X := X + alpha*Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void raddrv(int n,
            double alpha,
            double[,] y,
            int ridx,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_raddv(n, alpha, py+ridx*y.GetLength(1), px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] + alpha * y[ridx, i];
            }
        }

        /*************************************************************************
        Performs inplace addition of Y[RIdx,...] to X[RIdxDst]

        INPUT PARAMETERS:
            N       -   vector length
            Alpha   -   multiplier
            Y       -   array[?,N], matrix whose RIdxSrc-th row is added
            RIdxSrc -   source row index
            X       -   array[?,N], matrix whose RIdxDst-th row is target
            RIdxDst -   destination row index

        RESULT:
            X := X + alpha*Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void raddrr(int n,
            double alpha,
            double[,] y,
            int ridxsrc,
            double[,] x,
            int ridxdst,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_raddv(n, alpha, py+ridxsrc*y.GetLength(1), px+ridxdst*x.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[ridxdst, i] = x[ridxdst, i] + alpha * y[ridxsrc, i];
            }
        }

        /*************************************************************************
        Performs inplace multiplication of X[] by V

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process
            V       -   multiplier

        OUTPUT PARAMETERS:
            X       -   elements 0...N-1 multiplied by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmulv(int n,
            double v,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rmulv(n, v, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = x[i] * v;
            }
        }

        /*************************************************************************
        Performs inplace multiplication of X[] by V

        INPUT PARAMETERS:
            N       -   row length
            X       -   array[?,N], row to process
            V       -   multiplier

        OUTPUT PARAMETERS:
            X       -   elements 0...N-1 of row RowIdx are multiplied by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmulr(int n,
            double v,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rmulv(n, v, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif


            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = x[rowidx, i] * v;
            }
        }

        /*************************************************************************
        Performs inplace computation of Sqrt(X)

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process

        OUTPUT PARAMETERS:
            X       -   elements 0...N-1 replaced by Sqrt(X)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsqrtv(int n,
            double[] x,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rsqrtv(n, px) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[i] = System.Math.Sqrt(x[i]);
            }
        }

        /*************************************************************************
        Performs inplace computation of Sqrt(X[RowIdx,*])

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[?,N], matrix to process

        OUTPUT PARAMETERS:
            X       -   elements 0...N-1 replaced by Sqrt(X)

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsqrtr(int n,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rsqrtv(n, px+rowidx*x.GetLength(1)) )
                            return;
                    }
                }
#endif


            for (i = 0; i <= n - 1; i++)
            {
                x[rowidx, i] = System.Math.Sqrt(x[rowidx, i]);
            }
        }

        /*************************************************************************
        Performs inplace multiplication of X[OffsX:OffsX+N-1] by V

        INPUT PARAMETERS:
            N       -   subvector length
            X       -   vector to process
            V       -   multiplier

        OUTPUT PARAMETERS:
            X       -   elements OffsX:OffsX+N-1 multiplied by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rmulvx(int n,
            double v,
            double[] x,
            int offsx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rmulv(n, v, px+offsx) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                x[offsx + i] = x[offsx + i] * v;
            }
        }

        /*************************************************************************
        Returns maximum X

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process

        OUTPUT PARAMETERS:
            max(X[i])
            zero for N=0

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rmaxv(int n,
            double[] x,
            alglib.xparams _params)
        {
        
          =  ;
            in t  i = 0 ; 
            dobl            =0 )
                     
    retn           
         
         
         
        }
        

         
          
         
         
         
         
        e
        su
        lt                  i
        <
        =n-1; 
        i
        +
        )
         
              
         
           {
        

            
         
         
         
              
         
         
        v
         
        =                   i( v>result )
                {
                    result = v;
                }
            }
            return result;
        }

        /*************************************************************************
        Returns maximum |X|

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], vector to process

        OUTPUT PARAMETERS:
            max(|X[i]|)
            zero for N=0

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rmaxabsv(int n,
            double[] x,
            alglib.xparams _params)
            
         
         
        d
        oub0;
            int i = 0;
            double v = 0;

            result = 0;
            for(i=0; i<=n-1; i++)
            {
                v = System.Math.Abs(x[i]);
                if( v>result )
                {
                    result = v;
                }
            }
            return     }

        /*************************************************************************
        Returns maximum X

        INPUT PARAMETERS:
            N       -   vector length
            X       -   matrix to process, RowIdx-th row is processed

        OUTPUT PARAMETERS:
            max(X[RowIdx,i])
            zero for N=0

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rmaxr(int n,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
 
         
           
         
                  sult =
         
        0
        

                  t i = 
        0
        ;
     
              d
        ouble v = 0
         if( n
        =0 )
 
         
                    
         
         
         
         
        e
             
         
         
         
         e        
 
         
         
          
         
                            idx,0]
        

         
                   i<=n-
        ; i++)
        

         
        dx        ,i]        ;

         
         
         
         
         
                  >re
        s
        u
        l
        t
         
        
                    
         
         
         
                                       
         
         
         
        }
        

         
         
                    
         
         
         
        return
        result;
        }

        /*************************************************************************
        Returns maximum |X|

        INPUT PARAMETERS:
            N       -   vector length
            X       -   matrix to process, RowIdx-th row is processed

        OUTPUT PARAMETERS:
            max(|X[RowIdx,i]|)
            zero for N=0

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static double rmaxabsr(int n,
            double[,] x,
            int rowidx,
            alglib.xparams _params)
        {
 
         
         
         
                  result
         
        = 0;
  
               
         
                   doub
        e v = 
        ;
        

                  sul
         
         
        ;
        
         or(i=0
         
        <
        n
        -;              
        

         
                  v =
         
        S
        y
        s
        t
        m
        .M
        a
        t
        h
        .
        b
        s(
        x[                  (
        v
        result
         
        )
  
         
           
         
         
         
         
         
         
                    
         
         
         
          resu
        t                         
         
         
         r              }

        /*************************************************************************
        Sets vector X[] to V

        INPUT PARAMETERS:
            N       -   vector length
            V       -   value to set
            X       -   array[N]

        OUTPUT PARAMETERS:
            X       -   leading N elements are replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsetv(int n,
            double v,
            double[] x,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rset(n, v, px) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                x[j] = v;
            }
        }

        /*************************************************************************
        Sets X[OffsX:OffsX+N-1] to V

        INPUT PARAMETERS:
            N       -   subvector length
            V       -   value to set
            X       -   array[N]

        OUTPUT PARAMETERS:
            X       -   X[OffsX:OffsX+N-1] is replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsetvx(int n,
            double v,
            double[] x,
            int offsx,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x)
                    {
                        if( try_rset(n, v, px+offsx) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                x[offsx + j] = v;
            }
        }

        /*************************************************************************
        Sets vector X[] to V

        INPUT PARAMETERS:
            N       -   vector length
            V       -   value to set
            X       -   array[N]

        OUTPUT PARAMETERS:
            X       -   leading N elements are replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void isetv(int n,
            int v,
            int[] x,
            alglib.xparams _params)
        {
              =
         
        ;
        
 
                   
        
                  ; j++)
                  ;
   
         
              
         
        }

         
         
            }

        /*************************************************************************
        Sets vector X[] to V

        INPUT PARAMETERS:
            N       -   vector length
            V       -   value to set
            X       -   array[N]

        OUTPUT PARAMETERS:
            X       -   leading N elements are replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void bsetv(int n,
            bool v,
            bool[] x,
            alglib.xparams _params)
           
              
          i                 
        for(j
        =0; j
        =n
        1; j++)
 
                  {
    
         
         
         
         
         
         
         
         
         
         
         
         
        x
        [
        j
        ]
         
        =
         
        v
        ;
        

         
         
         
         
         
         
         
         
         
         
         
         
        }
        

         
         
         
         
         
         
         
         
        }

        /*************************************************************************
        Sets matrix A[] to V

        INPUT PARAMETERS:
            M, N    -   rows/cols count
            V       -   value to set
            A       -   array[M,N]

        OUTPUT PARAMETERS:
            A       -   leading M rows, N cols are replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsetm(int m,
            int n,
            double v,
            double[,] a,
            alglib.xparams _params)
        {
            int i = 0;
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* pa = a)
                    {
                        for(i = 0; i<m; i++)
                        {
                            double *prow = pa+i*a.GetLength(1);
                            if( !try_rset(n, v, prow) )
                            {
                                for(j = 0; j<n; j++)
                                    prow[j] = v;
                            }
                        }
                    }
                    return;
                }
#endif

            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    a[i, j] = v;
                }
            }
        }

        /*************************************************************************
        Sets row I of A[,] to V

        INPUT PARAMETERS:
            N       -   vector length
            V       -   value to set
            A       -   array[N,N] or larger
            I       -   row index

        OUTPUT PARAMETERS:
            A       -   leading N elements of I-th row are replaced by V

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rsetr(int n,
            double v,
            double[,] a,
            int i,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* pa = a)
                    {
                        if( try_rset(n, v, pa+i*a.GetLength(1)) )
                            return;
                    }
                }
#endif


            for (j = 0; j <= n - 1; j++)
            {
                a[i, j] = v;
            }
        }

        /*************************************************************************
        Copies vector X[] to Y[]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], source
            Y       -   preallocated array[N]

        OUTPUT PARAMETERS:
            Y       -   leading N elements are replaced by X

            
        NOTE: destination and source should NOT overlap

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopyv(int n,
            double[] x,
            double[] y,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rcopy(n, px, py) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                y[j] = x[j];
            }
        }

        /*************************************************************************
        Copies vector X[] to Y[]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], source
            Y       -   preallocated array[N]

        OUTPUT PARAMETERS:
            Y       -   leading N elements are replaced by X

            
        NOTE: destination and source should NOT overlap

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void bcopyv(int n,
            bool[] x,
            bool[] y,
            alglib.xparams _params)
        {
        
     
         
          
         
        i
        nt         f          
         
             {
 
         
         
         
         
         
          
         
         
         
         
         
         y[j] = x
        [
        j
        ]
        ;
                    }
        }

        /*************************************************************************
        Copies vector X[] to Y[]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   source array
            Y       -   preallocated array[N]

        OUTPUT PARAMETERS:
            Y       -   X copied to Y

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void icopyv(int n,
            int[] x,
            int[] y,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(int* px = x, py = y)
                    {
                        if( try_icopy(n, px, py) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                y[j] = x[j];
            }
        }

        /*************************************************************************
        Performs copying with multiplication of V*X[] to Y[]

        INPUT PARAMETERS:
            N       -   vector length
            V       -   multiplier
            X       -   array[N], source
            Y       -   preallocated array[N]

        OUTPUT PARAMETERS:
            Y       -   array[N], Y = V*X

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopymulv(int n,
            double v,
            double[] x,
            double[] y,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rcopymul(n, v, px, py) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                y[i] = v * x[i];
            }
        }

        /*************************************************************************
        Performs copying with multiplication of V*X[] to Y[I,*]

        INPUT PARAMETERS:
            N       -   vector length
            V       -   multiplier
            X       -   array[N], source
            Y       -   preallocated array[?,N]
            RIdx    -   destination row index

        OUTPUT PARAMETERS:
            Y       -   Y[RIdx,...] = V*X

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopymulvr(int n,
            double v,
            double[] x,
            double[,] y,
            int ridx,
            alglib.xparams _params)
        {
            int i = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rcopymul(n, v, px, py+ridx*y.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (i = 0; i <= n - 1; i++)
            {
                y[ridx, i] = v * x[i];
            }
        }

        /*************************************************************************
        Copies vector X[] to row I of A[,]

        INPUT PARAMETERS:
            N       -   vector length
            X       -   array[N], source
            A       -   preallocated 2D array large enough to store result
            I       -   destination row index

        OUTPUT PARAMETERS:
            A       -   leading N elements of I-th row are replaced by X

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopyvr(int n,
            double[] x,
            double[,] a,
            int i,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, pa = a)
                    {
                        if( try_rcopy(n, px, pa+i*a.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                a[i, j] = x[j];
            }
        }

        /*************************************************************************
        Copies row I of A[,] to vector X[]

        INPUT PARAMETERS:
            N       -   vector length
            A       -   2D array, source
            I       -   source row index
            X       -   preallocated destination

        OUTPUT PARAMETERS:
            X       -   array[N], destination

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopyrv(int n,
            double[,] a,
            int i,
            double[] x,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, pa = a)
                    {
                        if( try_rcopy(n, pa+i*a.GetLength(1), px) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                x[j] = a[i, j];
            }
        }

        /*************************************************************************
        Copies row I of A[,] to row K of B[,].

        A[i,...] and B[k,...] may overlap.

        INPUT PARAMETERS:
            N       -   vector length
            A       -   2D array, source
            I       -   source row index
            B       -   preallocated destination
            K       -   destination row index

        OUTPUT PARAMETERS:
            B       -   row K overwritten

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopyrr(int n,
            double[,] a,
            int i,
            double[,] b,
            int k,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* pa = a, pb = b)
                    {
                        if( try_rcopy(n, pa+i*a.GetLength(1), pb+k*b.GetLength(1)) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                b[k, j] = a[i, j];
            }
        }

        /*************************************************************************
        Copies vector X[] to Y[], extended version

        INPUT PARAMETERS:
            N       -   vector length
            X       -   source array
            OffsX   -   source offset
            Y       -   preallocated array[N]
            OffsY   -   destination offset

        OUTPUT PARAMETERS:
            Y       -   N elements starting from OffsY are replaced by X[OffsX:OffsX+N-1]
            
        NOTE: destination and source should NOT overlap

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void rcopyvx(int n,
            double[] x,
            int offsx,
            double[] y,
            int offsy,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(double* px = x, py = y)
                    {
                        if( try_rcopy(n, px+offsx, py+offsy) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                y[offsy + j] = x[offsx + j];
            }
        }

        /*************************************************************************
        Copies vector X[] to Y[], extended version

        INPUT PARAMETERS:
            N       -   vector length
            X       -   source array
            OffsX   -   source offset
            Y       -   preallocated array[N]
            OffsY   -   destination offset

        OUTPUT PARAMETERS:
            Y       -   N elements starting from OffsY are replaced by X[OffsX:OffsX+N-1]
            
        NOTE: destination and source should NOT overlap

          -- ALGLIB --
             Copyright 20.01.2020 by Bochkanov Sergey
        *************************************************************************/
        public static void icopyvx(int n,
            int[] x,
            int offsx,
            int[] y,
            int offsy,
            alglib.xparams _params)
        {
            int j = 0;

#if ALGLIB_USE_SIMD
            if( n>=_ABLASF_KERNEL_SIZE1 )
                unsafe
                {
                    fixed(int* px = x, py = y)
                    {
                        if( try_icopy(n, px+offsx, py+offsy) )
                            return;
                    }
                }
#endif

            for (j = 0; j <= n - 1; j++)
            {
                y[offsy + j] = x[offsx + j];
            }
        }


#if ALGLIB_USE_SIMD
        /*************************************************************************
        SIMD kernel for rgemv() and rgemvx()

          -- ALGLIB --
             Copyright 20.07.2021 by Bochkanov Sergey
        *************************************************************************/
        private static unsafe bool try_rgemv(
            int m,
            int n,
            double  alpha,
            double* a,
            int stride_a,
            int opa,
            double* x,
            double* y)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                if( opa==0 )
                {
                    
                    //
                    // y += A*x
                    //
                    int n4 = n>>2;
                    int head = n4<<2;
                    double *a_row = a;
                    int i, j;
                    double *vdot = stackalloc double[4];
                    for(i = 0; i<m; i++)
                    {
                        Intrinsics.Vector256<double> simd_dot = Intrinsics.Vector256<double>.Zero;
                        for(j = 0; j<head; j += 4)
                            simd_dot = Fma.MultiplyAdd(Fma.LoadVector256(a_row+j), Fma.LoadVector256(x+j), simd_dot);
                        Fma.Store(vdot, simd_dot);
                        for(j = head; j<n; j++)
                            vdot[0] += a_row[j]*x[j];
                        double v = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                        y[i] = alpha*v+y[i];
                        a_row += stride_a;
                    }
                    return true;
                }
                if( opa==1 )
                {
                    
                    //
                    // y += A^T*x
                    //
                    double *a_row = a;
                    int i, j;
                    int m4 = m>>2;
                    int head = m4<<2;
                    for(i = 0; i<n; i++)
                    {
                        double v = alpha*x[i];
                        Intrinsics.Vector256<double> simd_v = Fma.BroadcastScalarToVector256(&v);
                        for(j = 0; j<head; j += 4)
                            Fma.Store(y+j, Fma.MultiplyAdd(Fma.LoadVector256(a_row+j), simd_v, Fma.LoadVector256(y+j)));
                        for(j = head; j<m; j++)
                            y[j] += v*a_row[j];
                        a_row += stride_a;
                    }
                    return true;
                }
                return false;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                if( opa==0 )
                {
                    
                    //
                    // y += A*x
                    //
                    int n4 = n>>2;
                    int head = n4<<2;
                    double *a_row = a;
                    int i, j;
                    double *vdot = stackalloc double[4];
                    for(i = 0; i<m; i++)
                    {
                        Intrinsics.Vector256<double> simd_dot = Intrinsics.Vector256<double>.Zero;
                        for(j = 0; j<head; j += 4)
                            simd_dot =
 Avx2.Add(Avx2.Multiply(Avx2.LoadVector256(a_row+j), Avx2.LoadVector256(x+j)), simd_dot);
                        Avx2.Store(vdot, simd_dot);
                        for(j = head; j<n; j++)
                            vdot[0] += a_row[j]*x[j];
                        double v = vdot[0]+vdot[1]+vdot[2]+vdot[3];
                        y[i] = alpha*v+y[i];
                        a_row += stride_a;
                    }
                    return true;
                }
                if( opa==1 )
                {
                    
                    //
                    // y += A^T*x
                    //
                    double *a_row = a;
                    int i, j;
                    int m4 = m>>2;
                    int head = m4<<2;
                    for(i = 0; i<n; i++)
                    {
                        double v = alpha*x[i];
                        Intrinsics.Vector256<double> simd_v = Avx2.BroadcastScalarToVector256(&v);
                        for(j = 0; j<head; j += 4)
                            Avx2.Store(y+j, Avx2.Add(Avx2.Multiply(Avx2.LoadVector256(a_row+j), simd_v), Avx2.LoadVector256(y+j)));
                        for(j = head; j<m; j++)
                            y[j] += v*a_row[j];
                        a_row += stride_a;
                    }
                    return true;
                }
                return false;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif

        /*************************************************************************
        Matrix-vector product: y := alpha*op(A)*x + beta*y

        NOTE: this  function  expects  Y  to  be  large enough to store result. No
              automatic preallocation happens for  smaller  arrays.  No  integrity
              checks is performed for sizes of A, x, y.

        INPUT PARAMETERS:
            M   -   number of rows of op(A)
            N   -   number of columns of op(A)
            Alpha-  coefficient
            A   -   source matrix
            OpA -   operation type:
                    * OpA=0     =>  op(A) = A
                    * OpA=1     =>  op(A) = A^T
            X   -   input vector, has at least N elements
            Beta-   coefficient
            Y   -   preallocated output array, has at least M elements

        OUTPUT PARAMETERS:
            Y   -   vector which stores result

        HANDLING OF SPECIAL CASES:
            * if M=0, then subroutine does nothing. It does not even touch arrays.
            * if N=0 or Alpha=0.0, then:
              * if Beta=0, then Y is filled by zeros. A and X are  not  referenced
                at all. Initial values of Y are ignored (we do not  multiply  Y by
                zero, we just rewrite it by zeros)
              * if Beta<>0, then Y is replaced by Beta*Y
            * if M>0, N>0, Alpha<>0, but  Beta=0,  then  Y  is  replaced  by  A*x;
               initial state of Y is ignored (rewritten by  A*x,  without  initial
               multiplication by zeros).


          -- ALGLIB routine --

             01.09.2021
             Bochkanov Sergey
        *************************************************************************/
        public static void rgemv(int m,
            int n,
            double alpha,
            double[,] a,
            int opa,
            double[] x,
            double beta,
            double[] y,
            alglib.xparams _params)
        {
            int i = 0;
            int j = 0;
            double v = 0;


            //
            // Properly premultiply Y by Beta.
            //
            // Quick exit for M=0, N=0 or Alpha=0.
            // After this block we have M>0, N>0, Alpha<>0.
            //
            if (m <= 0)
            {
                return;
            }

            if ((double)(beta) != (double)(0))
            {
                rmulv(m, beta, y, _params);
            }
            else
            {
                rsetv(m, 0.0, y, _params);
            }

            if (n <= 0 || (double)(alpha) == (double)(0.0))
            {
                return;
            }

            //
            // Try fast kernel
            //
#if ALGLIB_USE_SIMD
            if( (opa==0 && n>=_ABLASF_KERNEL_SIZE2) || (opa==1 && m>=_ABLASF_KERNEL_SIZE2) )
                unsafe
                {
                    fixed(double* pa = a, px = x, py = y)
                    {
                        if( try_rgemv(m, n, alpha, pa, a.GetLength(1), opa, px, py) )
                            return;
                    }
                }
#endif

            //
            // Generic code
            //
            if (opa == 0)
            {
                //
                // y += A*x
                //
                for (i = 0; i <= m - 1; i++)
                {
                    v = 0;
                    for (j = 0; j <= n - 1; j++)
                    {
                        v = v + a[i, j] * x[j];
                    }

                    y[i] = alpha * v + y[i];
                }

                return;
            }

            if (opa == 1)
            {
                //
                // y += A^T*x
                //
                for (i = 0; i <= n - 1; i++)
                {
                    v = alpha * x[i];
                    for (j = 0; j <= m - 1; j++)
                    {
                        y[j] = y[j] + v * a[i, j];
                    }
                }

                return;
            }
        }

        /*************************************************************************
        Matrix-vector product: y := alpha*op(A)*x + beta*y

        Here x, y, A are subvectors/submatrices of larger vectors/matrices.

        NOTE: this  function  expects  Y  to  be  large enough to store result. No
              automatic preallocation happens for  smaller  arrays.  No  integrity
              checks is performed for sizes of A, x, y.

        INPUT PARAMETERS:
            M   -   number of rows of op(A)
            N   -   number of columns of op(A)
            Alpha-  coefficient
            A   -   source matrix
            IA  -   submatrix offset (row index)
            JA  -   submatrix offset (column index)
            OpA -   operation type:
                    * OpA=0     =>  op(A) = A
                    * OpA=1     =>  op(A) = A^T
            X   -   input vector, has at least N+IX elements
            IX  -   subvector offset
            Beta-   coefficient
            Y   -   preallocated output array, has at least M+IY elements
            IY  -   subvector offset

        OUTPUT PARAMETERS:
            Y   -   vector which stores result

        HANDLING OF SPECIAL CASES:
            * if M=0, then subroutine does nothing. It does not even touch arrays.
            * if N=0 or Alpha=0.0, then:
              * if Beta=0, then Y is filled by zeros. A and X are  not  referenced
                at all. Initial values of Y are ignored (we do not  multiply  Y by
                zero, we just rewrite it by zeros)
              * if Beta<>0, then Y is replaced by Beta*Y
            * if M>0, N>0, Alpha<>0, but  Beta=0,  then  Y  is  replaced  by  A*x;
               initial state of Y is ignored (rewritten by  A*x,  without  initial
               multiplication by zeros).


          -- ALGLIB routine --

             01.09.2021
             Bochkanov Sergey
        *************************************************************************/
        public static void rgemvx(int m,
            int n,
            double alpha,
            double[,] a,
            int ia,
            int ja,
            int opa,
            double[] x,
            int ix,
            double beta,
            double[] y,
            int iy,
            alglib.xparams _params)
        {
            int i = 0;
            int j = 0;
            double v = 0;


            //
            // Properly premultiply Y by Beta.
            //
            // Quick exit for M=0, N=0 or Alpha=0.
            // After this block we have M>0, N>0, Alpha<>0.
            //
            if (m <= 0)
            {
                return;
            }

            if ((double)(beta) != (double)(0))
            {
                rmulvx(m, beta, y, iy, _params);
            }
            else
            {
                rsetvx(m, 0.0, y, iy, _params);
            }

            if (n <= 0 || (double)(alpha) == (double)(0.0))
            {
                return;
            }

            //
            // Try fast kernel
            //
#if ALGLIB_USE_SIMD
            if( (opa==0 && n>=_ABLASF_KERNEL_SIZE2) || (opa==1 && m>=_ABLASF_KERNEL_SIZE2) )
                unsafe
                {
                    fixed(double* pa = a, px = x, py = y)
                    {
                        if( try_rgemv(m, n, alpha, pa+ia*a.GetLength(1)+ja, a.GetLength(1), opa, px+ix, py+iy) )
                            return;
                    }
                }
#endif

            //
            // Generic code
            //
            if (opa == 0)
            {
                //
                // y += A*x
                //
                for (i = 0; i <= m - 1; i++)
                {
                    v = 0;
                    for (j = 0; j <= n - 1; j++)
                    {
                        v = v + a[ia + i, ja + j] * x[ix + j];
                    }

                    y[iy + i] = alpha * v + y[iy + i];
                }

                return;
            }

            if (opa == 1)
            {
                //
                // y += A^T*x
                //
                for (i = 0; i <= n - 1; i++)
                {
                    v = alpha * x[ix + i];
                    for (j = 0; j <= m - 1; j++)
                    {
                        y[iy + j] = y[iy + j] + v * a[ia + i, ja + j];
                    }
                }

                return;
            }
        }


        /*************************************************************************
        Rank-1 correction: A := A + alpha*u*v'

        NOTE: this  function  expects  A  to  be  large enough to store result. No
              automatic preallocation happens for  smaller  arrays.  No  integrity
              checks is performed for sizes of A, u, v.

        INPUT PARAMETERS:
            M   -   number of rows
            N   -   number of columns
            A   -   target MxN matrix
            Alpha-  coefficient
            U   -   vector #1
            V   -   vector #2


          -- ALGLIB routine --
             07.09.2021
             Bochkanov Sergey
        *************************************************************************/
        public static void rger(int m,
            int n,
            double alpha,
            double[] u,
            double[] v,
            double[,] a,
            alglib.xparams _params)
        {
    
         
              
         
        nt
        i
        =
         
        ;

         
         
         
          
         
         
        in         d          
        i
        ( (m<=0 |
        |
         
        n
        =
        0
         || (
        d
        ub
        l
        e)
        (
        a
        l
        pha)==(do
        u
        b
        l
        e
        )(
        0
         
        )
        
        
         
         
         
         
        
  
         
          
         
          
         
          
         
          
        r
        tu          for(
        i=                    pha*u[i]                   j<=n-1; j++)
            {
          
         
           
        a[
        ,
        j]        vj                           }


        /*************************************************************************
        This subroutine solves linear system op(A)*x=b where:
        * A is NxN upper/lower triangular/unitriangular matrix
        * X and B are Nx1 vectors
        * "op" may be identity transformation or transposition

        Solution replaces X.

        IMPORTANT: * no overflow/underflow/denegeracy tests is performed.
                   * no integrity checks for operand sizes, out-of-bounds accesses
                     and so on is performed

        INPUT PARAMETERS
            N   -   matrix size, N>=0
            A       -   matrix, actial matrix is stored in A[IA:IA+N-1,JA:JA+N-1]
            IA      -   submatrix offset
            JA      -   submatrix offset
            IsUpper -   whether matrix is upper triangular
            IsUnit  -   whether matrix is unitriangular
            OpType  -   transformation type:
                        * 0 - no transformation
                        * 1 - transposition
            X       -   right part, actual vector is stored in X[IX:IX+N-1]
            IX      -   offset
            
        OUTPUT PARAMETERS
            X       -   solution replaces elements X[IX:IX+N-1]

          -- ALGLIB routine --
             (c) 07.09.2021 Bochkanov Sergey
        *************************************************************************/
        public static void rtrsvx(int n,
            double[,] a,
            int ia,
            int ja,
            bool isupper,
            bool isunit,
            int optype,
            double[] x,
            int ix,
            alglib.xparams _params)
        {
    
         
         
         
                  
     
         
         
         
                        
         
         
         
         
         d        

    
         
               
        f( n<=0
         )
        
                   re        u
         
           
         
        f
         
        op        supper
        )
         
         
         
                   
         
         
          
         
        fo        r
        n-        ;         i>        ; 
        --        )
                              
                                                 {

         
          
         
                                                            
                   
         
        ;         ++)

                               
                   
         
         
         
         
          
         
         
         
         
        v
         =
         v        ]*         
         
             
         
         
         
         
        }
        
            
        i
        f
        (
         
        !
        s
        un
        i
        t
         
        )
         
          
                  

        v
         =        v/        a
        [
        a
        i
        ,
        j
        a
        +
        i
        ]
        ;
        

         
         
         
         
                                  x[ix+ = v;
                }
                return;
            }
            if( optype==0 && !isupper )
            {
                for(i=0; i<=n-1; i++)
                {
                    v = x[ix+i];
                    for(j=0; j<=i-1; j++)
                    {
                        v = v-a[ia+i,ja+j]*x[ix+j];
                    }
                    if( !isunit )
                    {
                        v = v/a[ia+i,ja+i];
                    }
                    x[ix+i] = v;
                }
                return;
            }
            if( optype==1 && isupper )
            {
                for(i=0; i<=n-1; i++)
                {
                    v = x[ix+i];
                    if( !isunit )
                    {
                        v = v/a[ia+i,ja+i];
                    }
                    x[ix+i] = v;
                    if( v==0 )
                    {
                        continue;
                    }
                    for(j=i+1; j<=n-1; j++)
                    {
                        x[ix+j] = x[ix+j]-v*a[ia+i,ja+j];
                    }
                }
                return;
            }
            if( optype==1 && !isupper )
            {
                for(i=n-1; i>=0; i--)
                {
                    v = x[ix+i];
                    if( !isunit )
                    {
                        v = v/a[ia+i,ja+i
        ;
    
            
              
         
           
        

                        
        x
        [
        i
        +
        i]           
          
                  =0 
        
 
                      
        {
     
                      
        contin
        ue           
              
        }
              
         
         
        o
        r(         j+
        )

                        
        {
        
      
               
                  x[        +j]
        v
        a
        i
        a+           
         
         
         
                        
         
         
         
        }           
         
        e
        tu
        r
        ;
        }
        ib.ap.
        as        "r        ec
        t
        d oper
        at
        i
        n 
        ype");

               }


        /*************************************************************************
        Fast kernel (new version with AVX2/FMA)

          -- ALGLIB routine --
             19.09.2021
             Bochkanov Sergey
        *************************************************************************/
#if ALGLIB_USE_SIMD
        /*************************************************************************
        Block packing function for fast rGEMM. Loads long  WIDTH*LENGTH  submatrix
        with LENGTH<=BLOCK_SIZE and WIDTH<=MICRO_SIZE into contiguous  MICRO_SIZE*
        BLOCK_SIZE row-wise 'horizontal' storage (hence H in the function name).

        The matrix occupies first ROUND_LENGTH cols of the  storage  (with  LENGTH
        being rounded up to nearest SIMD granularity).  ROUND_LENGTH  is  returned
        as result. It is guaranteed that ROUND_LENGTH depends only on LENGTH,  and
        that it will be same for all function calls.

        Unused rows and columns in [LENGTH,ROUND_LENGTH) range are filled by zeros;
        unused cols in [ROUND_LENGTH,BLOCK_SIZE) range are ignored.

        * op=0 means that source is an WIDTH*LENGTH matrix stored with  src_stride
          stride. The matrix is NOT transposed on load.
        * op=1 means that source is an LENGTH*WIDTH matrix  stored with src_stride
          that is loaded with transposition
        * present version of the function supports only MICRO_SIZE=2, the behavior
          is undefined for other micro sizes.
        * the target is properly aligned; the source can be unaligned.

        Requires AVX2, does NOT check its presense.

        The function is present in two versions, one  with  variable  opsrc_length
        and another one with opsrc_length==block_size==32.

          -- ALGLIB routine --
             19.07.2021
             Bochkanov Sergey
        *************************************************************************/
        private static unsafe int ablasf_packblkh_avx2(
            double *src,
            int src_stride,
            int op,
            int opsrc_length,
            int opsrc_width,
            double   *dst,
            int block_size,
            int micro_size)
        {
            int i;
            
            /*
             * Write to the storage
             */
            if( op==0 )
            {
                /*
                 * Copy without transposition
                 */
                int len8 = (opsrc_length>>3)<<3;
                double *src1 = src+src_stride;
                double *dst1 = dst+block_size;
                if( opsrc_width==2 )
                {
                    /*
                     * Width=2
                     */
                    for(i = 0; i<len8; i += 8)
                    {
                        Avx2.StoreAligned(dst+i,    Avx2.LoadVector256(src+i));
                        Avx2.StoreAligned(dst+i+4,  Avx2.LoadVector256(src+i+4));
                        Avx2.StoreAligned(dst1+i,   Avx2.LoadVector256(src1+i));
                        Avx2.StoreAligned(dst1+i+4, Avx2.LoadVector256(src1+i+4));
                    }
                    for(i = len8; i<opsrc_length; i++)
                    {
                        dst[i] = src[i];
                        dst1[i] = src1[i];
                    }
                }
                else
                {
                    /*
                     * Width=1, pad by zeros
                     */
                    Intrinsics.Vector256<double> vz = Intrinsics.Vector256<double>.Zero;
                    for(i = 0; i<len8; i += 8)
                    {
                        Avx2.StoreAligned(dst+i,    Avx2.LoadVector256(src+i));
                        Avx2.StoreAligned(dst+i+4,  Avx2.LoadVector256(src+i+4));
                        Avx2.StoreAligned(dst1+i,   vz);
                        Avx2.StoreAligned(dst1+i+4, vz);
                    }
                    for(i = len8; i<opsrc_length; i++)
                    {
                        dst[i] = src[i];
                        dst1[i] = 0.0;
                    }
                }
            }
            else
            {
                /*
                 * Copy with transposition
                 */
                int stride2 = src_stride<<1;
                int stride3 = src_stride+stride2;
                int stride4 = src_stride<<2;
                int len4 = (opsrc_length>>2)<<2;
                double *srci = src;
                double *dst1 = dst+block_size;
                if( opsrc_width==2 )
                {
                    /*
                     * Width=2
                     */
                    for(i = 0; i<len4; i += 4)
                    {
                        Intrinsics.Vector128<double> s0 = Sse2.LoadVector128(srci),         s1 =
 Sse2.LoadVector128(srci+src_stride);
                        Intrinsics.Vector128<double> s2 = Sse2.LoadVector128(srci+stride2), s3 =
 Sse2.LoadVector128(srci+stride3);
                        Sse2.Store(dst+i,    Sse2.UnpackLow( s0,s1));
                        Sse2.Store(dst1+i,   Sse2.UnpackHigh(s0,s1));
                        Sse2.Store(dst+i+2,  Sse2.UnpackLow( s2,s3));
                        Sse2.Store(dst1+i+2, Sse2.UnpackHigh(s2,s3));
                        srci += stride4;
                    }
                    for(i = len4; i<opsrc_length; i++)
                    {
                        dst[i] = srci[0];
                        dst1[i] = srci[1];
                        srci += src_stride;
                    }
                }
                else
                {
                    /*
                     * Width=1, pad by zeros
                     */
                    Intrinsics.Vector128<double> vz = Intrinsics.Vector128<double>.Zero;
                    for(i = 0; i<len4; i += 4)
                    {
                        Intrinsics.Vector128<double> s0 = Sse2.LoadVector128(srci), s1 =
 Sse2.LoadVector128(srci+src_stride);
                        Intrinsics.Vector128<double> s2 = Sse2.LoadVector128(srci+stride2), s3 =
 Sse2.LoadVector128(srci+stride3);
                        Sse2.Store(dst+i,    Sse2.UnpackLow(s0,s1));
                        Sse2.Store(dst+i+2,  Sse2.UnpackLow(s2,s3));
                        Sse2.Store(dst1+i,   vz);
                        Sse2.Store(dst1+i+2, vz);
                        srci += stride4;
                    }
                    for(i = len4; i<opsrc_length; i++)
                    {
                        dst[i] = srci[0];
                        dst1[i] = 0.0;
                        srci += src_stride;
                    }
                }
            }
            
            /*
             * Pad by zeros, if needed
             */
            int round_length = ((opsrc_length+3)>>2)<<2;
            for(i = opsrc_length; i<round_length; i++)
            {
                dst[i] = 0;
                dst[i+block_size] = 0;
            }
            return round_length;
        }
        
        /*************************************************************************
        Computes  product   A*transpose(B)  of two MICRO_SIZE*ROUND_LENGTH rowwise 
        'horizontal' matrices, stored with stride=block_size, and writes it to the
        row-wise matrix C.

        ROUND_LENGTH is expected to be properly SIMD-rounded length,  as  returned
        by ablasf_packblkh_avx2().

        Present version of the function supports only MICRO_SIZE=2,  the  behavior
        is undefined for other micro sizes.

        Assumes that at least AVX2 is present; additionally checks for FMA and tries
        to use it.

          -- ALGLIB routine --
             19.07.2021
             Bochkanov Sergey
        *************************************************************************/
        private static unsafe void ablasf_dotblkh_avx2_fma(
            double *src_a,
            double *src_b,
            int round_length,
            int block_size,
            int micro_size,
            double *dst,
            int dst_stride)
        {
            int z;
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                /*
                 * Try FMA version
                 */
                Intrinsics.Vector256<double> r00 = Intrinsics.Vector256<double>.Zero,
                                             r01 = Intrinsics.Vector256<double>.Zero,
                                             r10 = Intrinsics.Vector256<double>.Zero,
                                             r11 = Intrinsics.Vector256<double>.Zero;
                if( (round_length&0x7)!=0 )
                {
                    /*
                     * round_length is multiple of 4, but not multiple of 8
                     */
                    for(z = 0; z<round_length; z += 4, src_a += 4, src_b += 4)
                    {
                        Intrinsics.Vector256<double> a0 = Fma.LoadAlignedVector256(src_a);
                        Intrinsics.Vector256<double> a1 = Fma.LoadAlignedVector256(src_a+block_size);
                        Intrinsics.Vector256<double> b0 = Fma.LoadAlignedVector256(src_b);
                        Intrinsics.Vector256<double> b1 = Fma.LoadAlignedVector256(src_b+block_size);
                        r00 = Fma.MultiplyAdd(a0, b0, r00);
                        r01 = Fma.MultiplyAdd(a0, b1, r01);
                        r10 = Fma.MultiplyAdd(a1, b0, r10);
                        r11 = Fma.MultiplyAdd(a1, b1, r11);
                    }
                }
                else
                {
                    /*
                     * round_length is multiple of 8
                     */
                    for(z = 0; z<round_length; z += 8, src_a += 8, src_b += 8)
                    {
                        Intrinsics.Vector256<double> a0 = Fma.LoadAlignedVector256(src_a);
                        Intrinsics.Vector256<double> a1 = Fma.LoadAlignedVector256(src_a+block_size);
                        Intrinsics.Vector256<double> b0 = Fma.LoadAlignedVector256(src_b);
                        Intrinsics.Vector256<double> b1 = Fma.LoadAlignedVector256(src_b+block_size);
                        Intrinsics.Vector256<double> c0 = Fma.LoadAlignedVector256(src_a+4);
                        Intrinsics.Vector256<double> c1 = Fma.LoadAlignedVector256(src_a+block_size+4);
                        Intrinsics.Vector256<double> d0 = Fma.LoadAlignedVector256(src_b+4);
                        Intrinsics.Vector256<double> d1 = Fma.LoadAlignedVector256(src_b+block_size+4);
                        r00 = Fma.MultiplyAdd(c0, d0, Fma.MultiplyAdd(a0, b0, r00));
                        r01 = Fma.MultiplyAdd(c0, d1, Fma.MultiplyAdd(a0, b1, r01));
                        r10 = Fma.MultiplyAdd(c1, d0, Fma.MultiplyAdd(a1, b0, r10));
                        r11 = Fma.MultiplyAdd(c1, d1, Fma.MultiplyAdd(a1, b1, r11));
                    }
                }
                Intrinsics.Vector256<double> sum0 = Fma.HorizontalAdd(r00,r01);
                Intrinsics.Vector256<double> sum1 = Fma.HorizontalAdd(r10,r11);
                Sse2.Store(dst,            Sse2.Add(Fma.ExtractVector128(sum0,0), Fma.ExtractVector128(sum0,1)));
                Sse2.Store(dst+dst_stride, Sse2.Add(Fma.ExtractVector128(sum1,0), Fma.ExtractVector128(sum1,1)));
            }
            else
            #endif // no-fma
            {
                /*
                 * Only AVX2 is present
                 */
                Intrinsics.Vector256<double> r00 = Intrinsics.Vector256<double>.Zero,
                                             r01 = Intrinsics.Vector256<double>.Zero,
                                             r10 = Intrinsics.Vector256<double>.Zero,
                                             r11 = Intrinsics.Vector256<double>.Zero;
                if( (round_length&0x7)!=0 )
                {
                    /*
                     * round_length is multiple of 4, but not multiple of 8
                     */
                    for(z = 0; z<round_length; z += 4, src_a += 4, src_b += 4)
                    {
                        Intrinsics.Vector256<double> a0 = Avx2.LoadAlignedVector256(src_a);
                        Intrinsics.Vector256<double> a1 = Avx2.LoadAlignedVector256(src_a+block_size);
                        Intrinsics.Vector256<double> b0 = Avx2.LoadAlignedVector256(src_b);
                        Intrinsics.Vector256<double> b1 = Avx2.LoadAlignedVector256(src_b+block_size);
                        r00 = Avx2.Add(Avx2.Multiply(a0, b0), r00);
                        r01 = Avx2.Add(Avx2.Multiply(a0, b1), r01);
                        r10 = Avx2.Add(Avx2.Multiply(a1, b0), r10);
                        r11 = Avx2.Add(Avx2.Multiply(a1, b1), r11);
                    }
                }
                else
                {
                    /*
                     * round_length is multiple of 8
                     */
                    for(z = 0; z<round_length; z += 8, src_a += 8, src_b += 8)
                    {
                        Intrinsics.Vector256<double> a0 = Avx2.LoadAlignedVector256(src_a);
                        Intrinsics.Vector256<double> a1 = Avx2.LoadAlignedVector256(src_a+block_size);
                        Intrinsics.Vector256<double> b0 = Avx2.LoadAlignedVector256(src_b);
                        Intrinsics.Vector256<double> b1 = Avx2.LoadAlignedVector256(src_b+block_size);
                        Intrinsics.Vector256<double> c0 = Avx2.LoadAlignedVector256(src_a+4);
                        Intrinsics.Vector256<double> c1 = Avx2.LoadAlignedVector256(src_a+block_size+4);
                        Intrinsics.Vector256<double> d0 = Avx2.LoadAlignedVector256(src_b+4);
                        Intrinsics.Vector256<double> d1 = Avx2.LoadAlignedVector256(src_b+block_size+4);
                        r00 = Avx2.Add(Avx2.Multiply(c0, d0), Avx2.Add(Avx2.Multiply(a0, b0), r00));
                        r01 = Avx2.Add(Avx2.Multiply(c0, d1), Avx2.Add(Avx2.Multiply(a0, b1), r01));
                        r10 = Avx2.Add(Avx2.Multiply(c1, d0), Avx2.Add(Avx2.Multiply(a1, b0), r10));
                        r11 = Avx2.Add(Avx2.Multiply(c1, d1), Avx2.Add(Avx2.Multiply(a1, b1), r11));
                    }
                }
                Intrinsics.Vector256<double> sum0 = Avx2.HorizontalAdd(r00,r01);
                Intrinsics.Vector256<double> sum1 = Avx2.HorizontalAdd(r10,r11);
                Sse2.Store(dst,            Sse2.Add(Avx2.ExtractVector128(sum0,0), Avx2.ExtractVector128(sum0,1)));
                Sse2.Store(dst+dst_stride, Sse2.Add(Avx2.ExtractVector128(sum1,0), Avx2.ExtractVector128(sum1,1)));
            }
            #endif // no-avx2
            #endif // no-sse2
        }
        
        /*************************************************************************
        Y := alpha*X + beta*Y

        Requires AVX2, does NOT check its presense.

          -- ALGLIB routine --
             19.07.2021
             Bochkanov Sergey
        *************************************************************************/
        private static unsafe void ablasf_daxpby_avx2(
            int    n,
            double alpha,
            double *src,
            double beta,
            double *dst)
        {
            if( beta==1.0 )
            {
                /*
                 * The most optimized case: DST := alpha*SRC + DST
                 *
                 * First, we process leading elements with generic C code until DST is aligned.
                 * Then, we process central part, assuming that DST is properly aligned.
                 * Finally, we process tail.
                 */
                int i, n4;
                Intrinsics.Vector256<double> avx_alpha = Intrinsics.Vector256.Create(alpha);
                while( n>0 && ((((ulong)dst)&31)!=0) )
                {
                    *dst += alpha*(*src);
                    n--;
                    dst++;
                    src++;
                }
                n4 = (n>>2)<<2;
                for(i = 0; i<n4; i += 4)
                    Avx2.StoreAligned(dst+i, Avx2.Add(Avx2.Multiply(avx_alpha, Avx2.LoadVector256(src+i)), Avx2.LoadAlignedVector256(dst+i)));
                for(i = n4; i<n; i++)
                    dst[i] = alpha*src[i]+dst[i];
            }
            else if( beta!=0.0 )
            {
                /*
                 * Well optimized: DST := alpha*SRC + beta*DST
                 */
                int i, n4;
                Intrinsics.Vector256<double> avx_alpha = Intrinsics.Vector256.Create(alpha);
                Intrinsics.Vector256<double> avx_beta = Intrinsics.Vector256.Create(beta);
                while( n>0 && ((((ulong)dst)&31)!=0) )
                {
                    *dst = alpha*(*src) + beta*(*dst);
                    n--;
                    dst++;
                    src++;
                }
                n4 = (n>>2)<<2;
                for(i = 0; i<n4; i += 4)
                    Avx2.StoreAligned(dst+i, Avx2.Add(Avx2.Multiply(avx_alpha, Avx2.LoadVector256(src+i)), Avx2.Multiply(avx_beta,Avx2.LoadAlignedVector256(dst+i))));
                for(i = n4; i<n; i++)
                    dst[i] = alpha*src[i]+beta*dst[i];
            }
            else
            {
                /*
                 * Easy case: DST := alpha*SRC
                 */
                int i;
                for(i = 0; i<n; i++)
                    dst[i] = alpha*src[i];
            }
        }
#endif

        private static bool rgemm32basecase(int m,
            int n,
            int k,
            double alpha,
            double[,] _a,
            int ia,
            int ja,
            int optypea,
            double[,] _b,
            int ib,
            int jb,
            int optypeb,
            double beta,
            double[,] _c,
            int ic,
            int jc,
            alglib.xparams _params)
        {
#if !ALGLIB_USE_SIMD
            return false;
#else
            //
            // Quick exit
            //
            int block_size = 32;
            if( m<=_ABLASF_KERNEL_SIZE3 || n<=_ABLASF_KERNEL_SIZE3 || k<=_ABLASF_KERNEL_SIZE3 )
                return false;
            if( m>block_size || n>block_size || k>block_size || m==0 || n==0 || !Avx2.IsSupported )
                return false;
            
            //
            // Pin arrays and multiply using SIMD
            //
            int micro_size = 2;
            int alignment_doubles = 4;
            ulong alignment_bytes = (ulong)(alignment_doubles*sizeof(double));
            unsafe
            {
                fixed(double *c = &_c[ic,jc])
                {
                    int out0, out1;
                    int stride_c = _c.GetLength(1);
                    
                    /*
                     * Do we have alpha*A*B ?
                     */
                    if( alpha!=0 && k>0 )
                    {
                        fixed(double* a = &_a[ia,ja], b = &_b[ib,jb])
                        {
                            /*
                             * Prepare structures
                             */
                            int base0, base1, offs0;
                            int stride_a = _a.GetLength(1);
                            int stride_b = _b.GetLength(1);
                            double*      _blka = stackalloc double[block_size*micro_size+alignment_doubles];
                            double* _blkb_long = stackalloc double[block_size*block_size+alignment_doubles];
                            double*      _blkc = stackalloc double[micro_size*block_size+alignment_doubles];
                            double* blka =
 (double*)(((((ulong)_blka)+alignment_bytes-1)/alignment_bytes)*alignment_bytes);
                            double* storageb_long =
 (double*)(((((ulong)_blkb_long)+alignment_bytes-1)/alignment_bytes)*alignment_bytes);
                            double* blkc =
 (double*)(((((ulong)_blkc)+alignment_bytes-1)/alignment_bytes)*alignment_bytes);
                            
                            /*
                             * Pack transform(B) into precomputed block form
                             */
                            for(base1 = 0; base1<n; base1 += micro_size)
                            {
                                int lim1 = n-base1<micro_size ? n-base1 : micro_size;
                                double *curb = storageb_long+base1*block_size;
                                ablasf_packblkh_avx2(
                                    b + (optypeb==0 ? base1 : base1*stride_b), stride_b, optypeb==0 ? 1 : 0, k, lim1,
                                    curb, block_size, micro_size);
                            }
                            
                            /*
                             * Output
                             */
                            for(base0 = 0; base0<m; base0 += micro_size)
                            {
                                /*
                                 * Load block row of transform(A)
                                 */
                                int lim0 = m-base0<micro_size ? m-base0 : micro_size;
                                int round_k = ablasf_packblkh_avx2(
                                    a + (optypea==0 ? base0*stride_a : base0), stride_a, optypea, k, lim0,
                                    blka, block_size, micro_size);
                                    
                                /*
                                 * Compute block(A)'*entire(B)
                                 */
                                for(base1 = 0; base1<n; base1 += micro_size)
                                    ablasf_dotblkh_avx2_fma(blka, storageb_long+base1*block_size, round_k, block_size, micro_size, blkc+base1, block_size);

                                /*
                                 * Output block row of block(A)'*entire(B)
                                 */
                                for(offs0 = 0; offs0<lim0; offs0++)
                                    ablasf_daxpby_avx2(n, alpha, blkc+offs0*block_size, beta, c+(base0+offs0)*stride_c);
                            }
                        }
                    }
                    else
                    {
                        /*
                         * No A*B, just beta*C (degenerate case, not optimized)
                         */
                        if( beta==0 )
                        {
                            for(out0 = 0; out0<m; out0++)
                                for(out1 = 0; out1<n; out1++)
                                    c[out0*stride_c+out1] = 0.0;
                        }
                        else if( beta!=1 )
                        {
                            for(out0 = 0; out0<m; out0++)
                                for(out1 = 0; out1<n; out1++)
                                    c[out0*stride_c+out1] *= beta;
                        }
                    }
                }
            }
            return true;
#endif
        }
    }

    /*************************************************************************
    Sparse Cholesky/LDLT kernels
    *************************************************************************/
    public partial class spchol
    {
        private static int spsymmgetmaxsimd(alglib.xparams _params)
        {
#if ALGLIB_USE_SIMD
            return 4;
#else
            return 1;
#endif
        }

        /*************************************************************************
        Solving linear system: propagating computed supernode.

        Propagates computed supernode to the rest of the RHS  using  SIMD-friendly
        RHS storage format.

        INPUT PARAMETERS:

        OUTPUT PARAMETERS:

          -- ALGLIB routine --
             08.09.2021
             Bochkanov Sergey
        *************************************************************************/
        private static void propagatefwd(double[] x,
            int cols0,
            int blocksize,
            int[] superrowidx,
            int rbase,
            int offdiagsize,
            double[] rowstorage,
            int offss,
            int sstride,
            double[] simdbuf,
            int simdwidth,
            alglib.xparams _params)
        {
  
         
         
         
            i
        n
        t i 
        =
        0;
  
          
                   0;
            in
        t
         
        b
        seoff
        s
        = 0;
        

             
         
              doub
        l
         v =
         
        ;
        

        

             
         
             
         
        f
        or(k=0; 
        k
        <=                  su                  fs =         ss        /*
         * No A*B, just beta*C (degenerate case, not optimized)
         */         j]
        *
        [col
        s0
        +
        ];                  ] =
         
        v;
 
         
         
         
            
         
        }
        

            
          
         }

        /*************************************************************************
        Fast kernels for small supernodal updates: special 4x4x4x4 function.

        ! See comments on UpdateSupernode() for information  on generic supernodal
        ! updates, including notation used below.

        The generic update has following form:

            S := S - scatter(U*D*Uc')

        This specialized function performs AxBxCx4 update, i.e.:
        * S is a tHeight*A matrix with row stride equal to 4 (usually it means that
          it has 3 or 4 columns)
        * U is a uHeight*B matrix
        * Uc' is a B*C matrix, with C<=A
        * scatter() scatters rows and columns of U*Uc'
          
        Return value:
        * True if update was applied
        * False if kernel refused to perform an update (quick exit for unsupported
          combinations of input sizes)

          -- ALGLIB routine --
             20.09.2020
             Bochkanov Sergey
        *************************************************************************/
#if ALGLIB_USE_SIMD
        private static unsafe bool try_updatekernelabc4(double* rowstorage,
            int offss,
            int twidth,
            int offsu,
            int uheight,
            int urank,
            int urowstride,
            int uwidth,
            double* diagd,
            int offsd,
            int* raw2smap,
            int* superrowidx,
            int urbase)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int k;
                int targetrow;
                int targetcol;
                
                /*
                 * Filter out unsupported combinations (ones that are too sparse for the non-SIMD code)
                 */
                if( twidth<3||twidth>4 )
                    return false;
                if( uwidth<1||uwidth>4 )
                    return false;
                if( urank>4 )
                    return false;
                
                /*
                 * Shift input arrays to the beginning of the working area.
                 * Prepare SIMD masks
                 */
                Intrinsics.Vector256<double> v_rankmask = Fma.CompareGreaterThan(
                    Intrinsics.Vector256.Create((double)urank, (double)urank, (double)urank, (double)urank),
                    Intrinsics.Vector256.Create(0.0, 1.0, 2.0, 3.0));
                double *update_storage = rowstorage+offsu;
                double *target_storage = rowstorage+offss;
                superrowidx += urbase;
                
                /*
                 * Load head of the update matrix
                 */
                Intrinsics.Vector256<double> v_d0123 = Fma.MaskLoad(diagd+offsd, v_rankmask);
                Intrinsics.Vector256<double> u_0_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_1_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_2_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_3_0123 = Intrinsics.Vector256<double>.Zero;
                for(k = 0; k<=uwidth-1; k++)
                {
                    targetcol = raw2smap[superrowidx[k]];
                    if( targetcol==0 )
                        u_0_0123 = Fma.Multiply(v_d0123, Fma.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==1 )
                        u_1_0123 = Fma.Multiply(v_d0123, Fma.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==2 )
                        u_2_0123 = Fma.Multiply(v_d0123, Fma.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==3 )
                        u_3_0123 = Fma.Multiply(v_d0123, Fma.MaskLoad(update_storage+k*urowstride, v_rankmask));
                }
                
                /*
                 * Transpose head
                 */
                Intrinsics.Vector256<double> u01_lo = Fma.UnpackLow( u_0_0123,u_1_0123);
                Intrinsics.Vector256<double> u01_hi = Fma.UnpackHigh(u_0_0123,u_1_0123);
                Intrinsics.Vector256<double> u23_lo = Fma.UnpackLow( u_2_0123,u_3_0123);
                Intrinsics.Vector256<double> u23_hi = Fma.UnpackHigh(u_2_0123,u_3_0123);
                Intrinsics.Vector256<double> u_0123_0 = Fma.Permute2x128(u01_lo, u23_lo, 0x20);
                Intrinsics.Vector256<double> u_0123_1 = Fma.Permute2x128(u01_hi, u23_hi, 0x20);
                Intrinsics.Vector256<double> u_0123_2 = Fma.Permute2x128(u23_lo, u01_lo, 0x13);
                Intrinsics.Vector256<double> u_0123_3 = Fma.Permute2x128(u23_hi, u01_hi, 0x13);
                
                /*
                 * Run update
                 */
                if( urank==1 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Fma.Store(target_storage+targetrow,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+0), u_0123_0,
                                Fma.LoadVector256(target_storage+targetrow)));
                    }
                }
                if( urank==2 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Fma.Store(target_storage+targetrow,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+1), u_0123_1,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+0), u_0123_0,
                                Fma.LoadVector256(target_storage+targetrow))));
                    }
                }
                if( urank==3 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Fma.Store(target_storage+targetrow,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+2), u_0123_2,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+1), u_0123_1,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+0), u_0123_0,
                                Fma.LoadVector256(target_storage+targetrow)))));
                    }
                }
                if( urank==4 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Fma.Store(target_storage+targetrow,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+3), u_0123_3,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+2), u_0123_2,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+1), u_0123_1,
                            Fma.MultiplyAddNegated(Fma.BroadcastScalarToVector256(update_row+0), u_0123_0,
                                Fma.LoadVector256(target_storage+targetrow))))));
                    }
                }
                return true;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                int k;
                int targetrow;
                int targetcol;
                
                /*
                 * Filter out unsupported combinations (ones that are too sparse for the non-SIMD code)
                 */
                if( twidth<3||twidth>4 )
                    return false;
                if( uwidth<1||uwidth>4 )
                    return false;
                if( urank>4 )
                    return false;
                
                /*
                 * Shift input arrays to the beginning of the working area.
                 * Prepare SIMD masks
                 */
                Intrinsics.Vector256<double> v_rankmask = Avx2.CompareGreaterThan(
                    Intrinsics.Vector256.Create((double)urank, (double)urank, (double)urank, (double)urank),
                    Intrinsics.Vector256.Create(0.0, 1.0, 2.0, 3.0));
                double *update_storage = rowstorage+offsu;
                double *target_storage = rowstorage+offss;
                superrowidx += urbase;
                
                /*
                 * Load head of the update matrix
                 */
                Intrinsics.Vector256<double> v_d0123 = Avx2.MaskLoad(diagd+offsd, v_rankmask);
                Intrinsics.Vector256<double> u_0_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_1_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_2_0123 = Intrinsics.Vector256<double>.Zero;
                Intrinsics.Vector256<double> u_3_0123 = Intrinsics.Vector256<double>.Zero;
                for(k = 0; k<=uwidth-1; k++)
                {
                    targetcol = raw2smap[superrowidx[k]];
                    if( targetcol==0 )
                        u_0_0123 = Avx2.Multiply(v_d0123, Avx2.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==1 )
                        u_1_0123 = Avx2.Multiply(v_d0123, Avx2.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==2 )
                        u_2_0123 = Avx2.Multiply(v_d0123, Avx2.MaskLoad(update_storage+k*urowstride, v_rankmask));
                    if( targetcol==3 )
                        u_3_0123 = Avx2.Multiply(v_d0123, Avx2.MaskLoad(update_storage+k*urowstride, v_rankmask));
                }
                
                /*
                 * Transpose head
                 */
                Intrinsics.Vector256<double> u01_lo = Avx2.UnpackLow( u_0_0123,u_1_0123);
                Intrinsics.Vector256<double> u01_hi = Avx2.UnpackHigh(u_0_0123,u_1_0123);
                Intrinsics.Vector256<double> u23_lo = Avx2.UnpackLow( u_2_0123,u_3_0123);
                Intrinsics.Vector256<double> u23_hi = Avx2.UnpackHigh(u_2_0123,u_3_0123);
                Intrinsics.Vector256<double> u_0123_0 = Avx2.Permute2x128(u01_lo, u23_lo, 0x20);
                Intrinsics.Vector256<double> u_0123_1 = Avx2.Permute2x128(u01_hi, u23_hi, 0x20);
                Intrinsics.Vector256<double> u_0123_2 = Avx2.Permute2x128(u23_lo, u01_lo, 0x13);
                Intrinsics.Vector256<double> u_0123_3 = Avx2.Permute2x128(u23_hi, u01_hi, 0x13);
                
                /*
                 * Run update
                 */
                if( urank==1 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Avx2.Store(target_storage+targetrow,
                            Avx2.Subtract(Avx2.LoadVector256(target_storage+targetrow),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+0), u_0123_0)));
                    }
                }
                if( urank==2 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Avx2.Store(target_storage+targetrow,
                            Avx2.Subtract(Avx2.Subtract(Avx2.LoadVector256(target_storage+targetrow),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+1), u_0123_1)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+0), u_0123_0)));
                    }
                }
                if( urank==3 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Avx2.Store(target_storage+targetrow,
                            Avx2.Subtract(Avx2.Subtract(Avx2.Subtract(Avx2.LoadVector256(target_storage+targetrow),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+2), u_0123_2)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+1), u_0123_1)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+0), u_0123_0)));
                    }
                }
                if( urank==4 )
                {
                    for(k = 0; k<=uheight-1; k++)
                    {
                        targetrow = raw2smap[superrowidx[k]]*4;
                        double *update_row = rowstorage+offsu+k*urowstride;
                        Avx2.Store(target_storage+targetrow,
                            Avx2.Subtract(Avx2.Subtract(Avx2.Subtract(Avx2.Subtract(Avx2.LoadVector256(target_storage+targetrow),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+3), u_0123_3)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+2), u_0123_2)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+1), u_0123_1)),
                                Avx2.Multiply(Avx2.BroadcastScalarToVector256(update_row+0), u_0123_0)));
                    }
                }
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif
        private static bool updatekernelabc4(double[] rowstorage,
            int offss,
            int twidth,
            int offsu,
            int uheight,
            int urank,
            int urowstride,
            int uwidth,
            double[] diagd,
            int offsd,
            int[] raw2smap,
            int[] superrowidx,
            int urbase,
            alglib.xparams _params)
        {
#if ALGLIB_USE_SIMD
            unsafe
            {
                fixed(double* p_rowstorage = rowstorage, p_diagd = diagd)
                fixed(int* p_raw2smap = raw2smap, p_superrowidx = superrowidx)
                {
                    if( try_updatekernelabc4(p_rowstorage, offss, twidth, offsu, uheight, urank, urowstride, uwidth, p_diagd, offsd, p_raw2smap, p_superrowidx, urbase) )
                        return true;
                }
            }
#endif

            //
            // Fallback pure C# code
            //
            bool result = new bool();
            int k = 0;
            int targetrow = 0;
            int targetcol = 0;
            int offsk = 0;
            double d0 = 0;
            double d1 = 0;
            double d2 = 0;
            double d3 = 0;
            double u00 = 0;
            double u01 = 0;
            double u02 = 0;
            double u03 = 0;
            double u10 = 0;
            double u11 = 0;
            double u12 = 0;
            double u13 = 0;
            double u20 = 0;
            double u21 = 0;
            double u22 = 0;
            double u23 = 0;
            double u30 = 0;
            double u31 = 0;
            double u32 = 0;
            double u33 = 0;
            double uk0 = 0;
            double uk1 = 0;
            double uk2 = 0;
            double uk3 = 0;
            int srccol0 = 0;
            int srccol1 = 0;
            int srccol2 = 0;
            int srccol3 = 0;


            //
            // Filter out unsupported combinations (ones that are too sparse for the non-SIMD code)
            //
            result = false;
            if (twidth < 3 || twidth > 4)
            {
                return result;
            }

            if (uwidth < 3 || uwidth > 4)
            {
                return result;
            }

            if (urank > 4)
            {
                return result;
            }

            //
            // Determine source columns for target columns, -1 if target column
            // is not updated.
            //
            srccol0 = -1;
            srccol1 = -1;
            srccol2 = -1;
            srccol3 = -1;
            for (k = 0; k <= uwidth - 1; k++)
            {
                targetcol = raw2smap[superrowidx[urbase + k]];
                if (targetcol == 0)
                {
                    srccol0 = k;
                }

                if (targetcol == 1)
                {
                    srccol1 = k;
                }

                if (targetcol == 2)
                {
                    srccol2 = k;
                }

                if (targetcol == 3)
                {
                    srccol3 = k;
                }
            }

            //
            // Load update matrix into aligned/rearranged 4x4 storage
            //
            d0 = 0;
            d1 = 0;
            d2 = 0;
            d3 = 0;
            u00 = 0;
            u01 = 0;
            u02 = 0;
            u03 = 0;
            u10 = 0;
            u11 = 0;
            u12 = 0;
            u13 = 0;
            u20 = 0;
            u21 = 0;
            u22 = 0;
            u23 = 0;
            u30 = 0;
            u31 = 0;
            u32 = 0;
            u33 = 0;
            if (urank >= 1)
            {
                d0 = diagd[offsd + 0];
            }

            if (urank >= 2)
            {
                d1 = diagd[offsd + 1];
            }

            if (urank >= 3)
            {
                d2 = diagd[offsd + 2];
            }

            if (urank >= 4)
            {
                d3 = diagd[offsd + 3];
            }

            if (srccol0 >= 0)
            {
                if (urank >= 1)
                {
                    u00 = d0 * rowstorage[offsu + srccol0 * urowstride + 0];
                }

                if (urank >= 2)
                {
                    u01 = d1 * rowstorage[offsu + srccol0 * urowstride + 1];
                }

                if (urank >= 3)
                {
                    u02 = d2 * rowstorage[offsu + srccol0 * urowstride + 2];
                }

                if (urank >= 4)
                {
                    u03 = d3 * rowstorage[offsu + srccol0 * urowstride + 3];
                }
            }

            if (srccol1 >= 0)
            {
                if (urank >= 1)
                {
                    u10 = d0 * rowstorage[offsu + srccol1 * urowstride + 0];
                }

                if (urank >= 2)
                {
                    u11 = d1 * rowstorage[offsu + srccol1 * urowstride + 1];
                }

                if (urank >= 3)
                {
                    u12 = d2 * rowstorage[offsu + srccol1 * urowstride + 2];
                }

                if (urank >= 4)
                {
                    u13 = d3 * rowstorage[offsu + srccol1 * urowstride + 3];
                }
            }

            if (srccol2 >= 0)
            {
                if (urank >= 1)
                {
                    u20 = d0 * rowstorage[offsu + srccol2 * urowstride + 0];
                }

                if (urank >= 2)
                {
                    u21 = d1 * rowstorage[offsu + srccol2 * urowstride + 1];
                }

                if (urank >= 3)
                {
                    u22 = d2 * rowstorage[offsu + srccol2 * urowstride + 2];
                }

                if (urank >= 4)
                {
                    u23 = d3 * rowstorage[offsu + srccol2 * urowstride + 3];
                }
            }

            if (srccol3 >= 0)
            {
                if (urank >= 1)
                {
                    u30 = d0 * rowstorage[offsu + srccol3 * urowstride + 0];
                }

                if (urank >= 2)
                {
                    u31 = d1 * rowstorage[offsu + srccol3 * urowstride + 1];
                }

                if (urank >= 3)
                {
                    u32 = d2 * rowstorage[offsu + srccol3 * urowstride + 2];
                }

                if (urank >= 4)
                {
                    u33 = d3 * rowstorage[offsu + srccol3 * urowstride + 3];
                }
            }

            //
            // Run update
            //
            if (urank == 1)
            {
                for (k = 0; k <= uheight - 1; k++)
                {
                    targetrow = offss + raw2smap[superrowidx[urbase + k]] * 4;
                    offsk = offsu + k * urowstride;
                    uk0 = rowstorage[offsk + 0];
                    rowstorage[targetrow + 0] = rowstorage[targetrow + 0] - u00 * uk0;
                    rowstorage[targetrow + 1] = rowstorage[targetrow + 1] - u10 * uk0;
                    rowstorage[targetrow + 2] = rowstorage[targetrow + 2] - u20 * uk0;
                    rowstorage[targetrow + 3] = rowstorage[targetrow + 3] - u30 * uk0;
                }
            }

            if (urank == 2)
            {
                for (k = 0; k <= uheight - 1; k++)
                {
                    targetrow = offss + raw2smap[superrowidx[urbase + k]] * 4;
                    offsk = offsu + k * urowstride;
                    uk0 = rowstorage[offsk + 0];
                    uk1 = rowstorage[offsk + 1];
                    rowstorage[targetrow + 0] = rowstorage[targetrow + 0] - u00 * uk0 - u01 * uk1;
                    rowstorage[targetrow + 1] = rowstorage[targetrow + 1] - u10 * uk0 - u11 * uk1;
                    rowstorage[targetrow + 2] = rowstorage[targetrow + 2] - u20 * uk0 - u21 * uk1;
                    rowstorage[targetrow + 3] = rowstorage[targetrow + 3] - u30 * uk0 - u31 * uk1;
                }
            }

            if (urank == 3)
            {
                for (k = 0; k <= uheight - 1; k++)
                {
                    targetrow = offss + raw2smap[superrowidx[urbase + k]] * 4;
                    offsk = offsu + k * urowstride;
                    uk0 = rowstorage[offsk + 0];
                    uk1 = rowstorage[offsk + 1];
                    uk2 = rowstorage[offsk + 2];
                    rowstorage[targetrow + 0] = rowstorage[targetrow + 0] - u00 * uk0 - u01 * uk1 - u02 * uk2;
                    rowstorage[targetrow + 1] = rowstorage[targetrow + 1] - u10 * uk0 - u11 * uk1 - u12 * uk2;
                    rowstorage[targetrow + 2] = rowstorage[targetrow + 2] - u20 * uk0 - u21 * uk1 - u22 * uk2;
                    rowstorage[targetrow + 3] = rowstorage[targetrow + 3] - u30 * uk0 - u31 * uk1 - u32 * uk2;
                }
            }

            if (urank == 4)
            {
                for (k = 0; k <= uheight - 1; k++)
                {
                    targetrow = offss + raw2smap[superrowidx[urbase + k]] * 4;
                    offsk = offsu + k * urowstride;
                    uk0 = rowstorage[offsk + 0];
                    uk1 = rowstorage[offsk + 1];
                    uk2 = rowstorage[offsk + 2];
                    uk3 = rowstorage[offsk + 3];
                    rowstorage[targetrow + 0] =
                        rowstorage[targetrow + 0] - u00 * uk0 - u01 * uk1 - u02 * uk2 - u03 * uk3;
                    rowstorage[targetrow + 1] =
                        rowstorage[targetrow + 1] - u10 * uk0 - u11 * uk1 - u12 * uk2 - u13 * uk3;
                    rowstorage[targetrow + 2] =
                        rowstorage[targetrow + 2] - u20 * uk0 - u21 * uk1 - u22 * uk2 - u23 * uk3;
                    rowstorage[targetrow + 3] =
                        rowstorage[targetrow + 3] - u30 * uk0 - u31 * uk1 - u32 * uk2 - u33 * uk3;
                }
            }

            result = true;
            return result;
        }

        /*************************************************************************
        Fast kernels for small supernodal updates: special 4x4x4x4 function.

        ! See comments on UpdateSupernode() for information  on generic supernodal
        ! updates, including notation used below.

        The generic update has following form:

            S := S - scatter(U*D*Uc')

        This specialized function performs 4x4x4x4 update, i.e.:
        * S is a tHeight*4 matrix
        * U is a uHeight*4 matrix
        * Uc' is a 4*4 matrix
        * scatter() scatters rows of U*Uc', but does not scatter columns (they are
          densely packed).
          
        Return value:
        * True if update was applied
        * False if kernel refused to perform an update.

          -- ALGLIB routine --
             20.09.2020
             Bochkanov Sergey
        *************************************************************************/
#if ALGLIB_USE_SIMD
        private static unsafe bool try_updatekernel4444(double* rowstorage,
            int offss,
            int sheight,
            int offsu,
            int uheight,
            double *diagd,
            int offsd,
            int[] raw2smap,
            int[] superrowidx,
            int urbase)
        {
            #if !ALGLIB_NO_SSE2
            #if !ALGLIB_NO_AVX2
            #if !ALGLIB_NO_FMA
            if( Fma.IsSupported )
            {
                int k, targetrow, offsk;
                Intrinsics.Vector256<double> v_negd_u0, v_negd_u1, v_negd_u2, v_negd_u3, v_negd;
                Intrinsics.Vector256<double> v_w0, v_w1, v_w2, v_w3, u01_lo, u01_hi, u23_lo, u23_hi;
                
                /*
                 * Compute W = -D*transpose(U[0:3])
                 */
                v_negd = Avx2.Multiply(Avx2.LoadVector256(diagd+offsd),Intrinsics.Vector256.Create(-1.0));
                v_negd_u0 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+0*4),v_negd);
                v_negd_u1 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+1*4),v_negd);
                v_negd_u2 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+2*4),v_negd);
                v_negd_u3 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+3*4),v_negd);
                u01_lo = Avx2.UnpackLow( v_negd_u0,v_negd_u1);
                u01_hi = Avx2.UnpackHigh(v_negd_u0,v_negd_u1);
                u23_lo = Avx2.UnpackLow( v_negd_u2,v_negd_u3);
                u23_hi = Avx2.UnpackHigh(v_negd_u2,v_negd_u3);
                v_w0 = Avx2.Permute2x128(u01_lo, u23_lo, 0x20);
                v_w1 = Avx2.Permute2x128(u01_hi, u23_hi, 0x20);
                v_w2 = Avx2.Permute2x128(u23_lo, u01_lo, 0x13);
                v_w3 = Avx2.Permute2x128(u23_hi, u01_hi, 0x13);
                
                //
                // Compute update S:= S + row_scatter(U*W)
                //
                if( sheight==uheight )
                {
                    /*
                     * No row scatter, the most efficient code
                     */
                    for(k = 0; k<=uheight-1; k++)
                    {
                        Intrinsics.Vector256<double> target;
                        
                        targetrow = offss+k*4;
                        offsk = offsu+k*4;
                        
                        target = Avx2.LoadVector256(rowstorage+targetrow);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+0),v_w0,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+1),v_w1,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+2),v_w2,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+3),v_w3,target);
                        Avx2.Store(rowstorage+targetrow, target);
                    }
                }
                else
                {
                    /*
                     * Row scatter is performed, less efficient code using double mapping to determine target row index
                     */
                    for(k = 0; k<=uheight-1; k++)
                    {
                        Intrinsics.Vector256<double> target;
                        
                        targetrow = offss+raw2smap[superrowidx[urbase+k]]*4;
                        offsk = offsu+k*4;
                        
                        target = Avx2.LoadVector256(rowstorage+targetrow);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+0),v_w0,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+1),v_w1,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+2),v_w2,target);
                        target = Fma.MultiplyAdd(Avx2.BroadcastScalarToVector256(rowstorage+offsk+3),v_w3,target);
                        Avx2.Store(rowstorage+targetrow, target);
                    }
                }
                return true;
            }
            #endif // no-fma
            if( Avx2.IsSupported )
            {
                int k, targetrow, offsk;
                Intrinsics.Vector256<double> v_negd_u0, v_negd_u1, v_negd_u2, v_negd_u3, v_negd;
                Intrinsics.Vector256<double> v_w0, v_w1, v_w2, v_w3, u01_lo, u01_hi, u23_lo, u23_hi;
                
                /*
                 * Compute W = -D*transpose(U[0:3])
                 */
                v_negd = Avx2.Multiply(Avx2.LoadVector256(diagd+offsd),Intrinsics.Vector256.Create(-1.0));
                v_negd_u0 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+0*4),v_negd);
                v_negd_u1 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+1*4),v_negd);
                v_negd_u2 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+2*4),v_negd);
                v_negd_u3 = Avx2.Multiply(Avx2.LoadVector256(rowstorage+offsu+3*4),v_negd);
                u01_lo = Avx2.UnpackLow( v_negd_u0,v_negd_u1);
                u01_hi = Avx2.UnpackHigh(v_negd_u0,v_negd_u1);
                u23_lo = Avx2.UnpackLow( v_negd_u2,v_negd_u3);
                u23_hi = Avx2.UnpackHigh(v_negd_u2,v_negd_u3);
                v_w0 = Avx2.Permute2x128(u01_lo, u23_lo, 0x20);
                v_w1 = Avx2.Permute2x128(u01_hi, u23_hi, 0x20);
                v_w2 = Avx2.Permute2x128(u23_lo, u01_lo, 0x13);
                v_w3 = Avx2.Permute2x128(u23_hi, u01_hi, 0x13);
                
                //
                // Compute update S:= S + row_scatter(U*W)
                //
                if( sheight==uheight )
                {
                    /*
                     * No row scatter, the most efficient code
                     */
                    for(k = 0; k<=uheight-1; k++)
                    {
                        Intrinsics.Vector256<double> target;
                        
                        targetrow = offss+k*4;
                        offsk = offsu+k*4;
                        
                        target = Avx2.LoadVector256(rowstorage+targetrow);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+0),v_w0),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+1),v_w1),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+2),v_w2),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+3),v_w3),target);
                        Avx2.Store(rowstorage+targetrow, target);
                    }
                }
                else
                {
                    /*
                     * Row scatter is performed, less efficient code using double mapping to determine target row index
                     */
                    for(k = 0; k<=uheight-1; k++)
                    {
                        Intrinsics.Vector256<double> target;
                        
                        targetrow = offss+raw2smap[superrowidx[urbase+k]]*4;
                        offsk = offsu+k*4;
                        
                        target = Avx2.LoadVector256(rowstorage+targetrow);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+0),v_w0),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+1),v_w1),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+2),v_w2),target);
                        target =
 Avx2.Add(Avx2.Multiply(Avx2.BroadcastScalarToVector256(rowstorage+offsk+3),v_w3),target);
                        Avx2.Store(rowstorage+targetrow, target);
                    }
                }
                return true;
            }
            #endif // no-avx2
            #endif // no-sse2
            return false;
        }
#endif
        private static bool updatekernel4444(double[] rowstorage,
            int offss,
            int sheight,
            int offsu,
            int uheight,
            double[] diagd,
            int offsd,
            int[] raw2smap,
            int[] superrowidx,
            int urbase,
            alglib.xparams _params)
        {
#if ALGLIB_USE_SIMD
            unsafe
            {
                fixed(double* p_rowstorage = rowstorage, p_diagd = diagd)
                {
                    if( try_updatekernel4444(p_rowstorage, offss, sheight, offsu, uheight, p_diagd, offsd, raw2smap, superrowidx, urbase) )
                        return true;
                }
            }
#endif

            //
            // Fallback pure C# code
            //
            bool result = new bool();
            int k = 0;
            int targetrow = 0;
            int offsk = 0;
            double d0 = 0;
            double d1 = 0;
            double d2 = 0;
            double d3 = 0;
            double u00 = 0;
            double u01 = 0;
            double u02 = 0;
            double u03 = 0;
            double u10 = 0;
            double u11 = 0;
            double u12 = 0;
            double u13 = 0;
            double u20 = 0;
            double u21 = 0;
            double u22 = 0;
            double u23 = 0;
            double u30 = 0;
            double u31 = 0;
            double u32 = 0;
            double u33 = 0;
            double uk0 = 0;
            double uk1 = 0;
            double uk2 = 0;
            double uk3 = 0;

            d0 = diagd[offsd + 0];
            d1 = diagd[offsd + 1];
            d2 = diagd[offsd + 2];
            d3 = diagd[offsd + 3];
            u00 = d0 * rowstorage[offsu + 0 * 4 + 0];
            u01 = d1 * rowstorage[offsu + 0 * 4 + 1];
            u02 = d2 * rowstorage[offsu + 0 * 4 + 2];
            u03 = d3 * rowstorage[offsu + 0 * 4 + 3];
            u10 = d0 * rowstorage[offsu + 1 * 4 + 0];
            u11 = d1 * rowstorage[offsu + 1 * 4 + 1];
            u12 = d2 * rowstorage[offsu + 1 * 4 + 2];
            u13 = d3 * rowstorage[offsu + 1 * 4 + 3];
            u20 = d0 * rowstorage[offsu + 2 * 4 + 0];
            u21 = d1 * rowstorage[offsu + 2 * 4 + 1];
            u22 = d2 * rowstorage[offsu + 2 * 4 + 2];
            u23 = d3 * rowstorage[offsu + 2 * 4 + 3];
            u30 = d0 * rowstorage[offsu + 3 * 4 + 0];
            u31 = d1 * rowstorage[offsu + 3 * 4 + 1];
            u32 = d2 * rowstorage[offsu + 3 * 4 + 2];
            u33 = d3 * rowstorage[offsu + 3 * 4 + 3];
            for (k = 0; k <= uheight - 1; k++)
            {
                targetrow = offss + raw2smap[superrowidx[urbase + k]] * 4;
                offsk = offsu + k * 4;
                uk0 = rowstorage[offsk + 0];
                uk1 = rowstorage[offsk + 1];
                uk2 = rowstorage[offsk + 2];
                uk3 = rowstorage[offsk + 3];
                rowstorage[targetrow + 0] = rowstorage[targetrow + 0] - u00 * uk0 - u01 * uk1 - u02 * uk2 - u03 * uk3;
                rowstorage[targetrow + 1] = rowstorage[targetrow + 1] - u10 * uk0 - u11 * uk1 - u12 * uk2 - u13 * uk3;
                rowstorage[targetrow + 2] = rowstorage[targetrow + 2] - u20 * uk0 - u21 * uk1 - u22 * uk2 - u23 * uk3;
                rowstorage[targetrow + 3] = rowstorage[targetrow + 3] - u30 * uk0 - u31 * uk1 - u32 * uk2 - u33 * uk3;
            }

            result = true;
            return result;
        }
    }
}
#endif
public partial class alglib
{
    public partial class smp
    {
        public static int cores_count = 1;
        public static volatile int cores_to_use = 1;

        public static bool isparallelcontext()
        {        e;
   
            
        }
    }

    public class smpselftests
    {
        public static bool runtests()
        {

            
         
         
           re               }
    }

    public static void setnworkers(int nworkers)
       a
    glib.smp.
    o
    e
    s_    rke
    s;
  
     }

    public static int getnworkers()
    {
     
      
    e
    u
    rn    cores_
    o_
    s
    ;
    
    }
}