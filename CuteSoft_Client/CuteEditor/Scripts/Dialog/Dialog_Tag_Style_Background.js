var OxO964b=["SetStyle","length","","GetStyle","GetText",":",";","cssText","inp_color","inp_color_Preview","tb_image","btnbrowse","sel_bgrepeat","sel_bgattach","sel_hor","tb_hor","sel_hor_unit","sel_ver","tb_ver","sel_ver_unit","outer","div_demo","onclick","value","disabled","selectedIndex","style","backgroundImage","backgroundColor","backgroundRepeat","backgroundAttachment","backgroundPositionX","options","backgroundPositionY","url(",")","background-image","backgroundPosition","none"];function pause(Ox49b){var Oxa1= new Date();var Ox49c=Oxa1.getTime()+Ox49b;while(true){Oxa1= new Date();if(Oxa1.getTime()>Ox49c){return ;} ;} ;} ;function StyleClass(Ox1fa){var Ox49e=[];var Ox49f={};if(Ox1fa){Ox4a4();} ;this[OxO964b[0]]=function SetStyle(name,Ox4e,Ox4a1){name=name.toLowerCase();for(var i=0;i<Ox49e[OxO964b[1]];i++){if(Ox49e[i]==name){break ;} ;} ;Ox49e[i]=name;Ox49f[name]=Ox4e?(Ox4e+(Ox4a1||OxO964b[2])):OxO964b[2];} ;this[OxO964b[3]]=function GetStyle(name){name=name.toLowerCase();return Ox49f[name]||OxO964b[2];} ;this[OxO964b[4]]=function Ox4a3(){var Ox1fa=OxO964b[2];for(var i=0;i<Ox49e[OxO964b[1]];i++){var n=Ox49e[i];var p=Ox49f[n];if(p){Ox1fa+=n+OxO964b[5]+p+OxO964b[6];} ;} ;return Ox1fa;} ;function Ox4a4(){var arr=Ox1fa.split(OxO964b[6]);for(var i=0;i<arr[OxO964b[1]];i++){var p=arr[i].split(OxO964b[5]);var n=p[0].replace(/^\s+/g,OxO964b[2]).replace(/\s+$/g,OxO964b[2]).toLowerCase();Ox49e[Ox49e[OxO964b[1]]]=n;Ox49f[n]=p[1];} ;} ;} ;function GetStyle(Ox130,name){return  new StyleClass(Ox130.cssText).GetStyle(name);} ;function SetStyle(Ox130,name,Ox4e,Ox4a5){var Ox4a6= new StyleClass(Ox130.cssText);Ox4a6.SetStyle(name,Ox4e,Ox4a5);Ox130[OxO964b[7]]=Ox4a6.GetText();} ;function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO964b[2];} ;return Ox8+OxO964b[2];} ;var inp_color=Window_GetElement(window,OxO964b[8],true);var inp_color_Preview=Window_GetElement(window,OxO964b[9],true);var tb_image=Window_GetElement(window,OxO964b[10],true);var btnbrowse=Window_GetElement(window,OxO964b[11],true);var sel_bgrepeat=Window_GetElement(window,OxO964b[12],true);var sel_bgattach=Window_GetElement(window,OxO964b[13],true);var sel_hor=Window_GetElement(window,OxO964b[14],true);var tb_hor=Window_GetElement(window,OxO964b[15],true);var sel_hor_unit=Window_GetElement(window,OxO964b[16],true);var sel_ver=Window_GetElement(window,OxO964b[17],true);var tb_ver=Window_GetElement(window,OxO964b[18],true);var sel_ver_unit=Window_GetElement(window,OxO964b[19],true);var outer=Window_GetElement(window,OxO964b[20],true);var div_demo=Window_GetElement(window,OxO964b[21],true);btnbrowse[OxO964b[22]]=function btnbrowse_onclick(){function Ox354(Ox137){if(Ox137){tb_image[OxO964b[23]]=Ox137;} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectImageDialog(Ox354,tb_image.value,tb_image);} else {editor.ShowSelectImageDialog(Ox354,tb_image.value);} ;} ;UpdateState=function UpdateState_Background(){tb_hor[OxO964b[24]]=sel_hor_unit[OxO964b[24]]=(sel_hor[OxO964b[25]]>0);tb_ver[OxO964b[24]]=sel_ver_unit[OxO964b[24]]=(sel_ver[OxO964b[25]]>0);div_demo[OxO964b[26]][OxO964b[7]]=element[OxO964b[26]][OxO964b[7]];} ;SyncToView=function SyncToView_Background(){tb_image[OxO964b[23]]=element[OxO964b[26]][OxO964b[27]];FixTbImage();inp_color[OxO964b[23]]=element[OxO964b[26]][OxO964b[28]];inp_color[OxO964b[26]][OxO964b[28]]=element[OxO964b[26]][OxO964b[28]];inp_color_Preview[OxO964b[26]][OxO964b[28]]=element[OxO964b[26]][OxO964b[28]];sel_bgrepeat[OxO964b[23]]=element[OxO964b[26]][OxO964b[29]];sel_bgattach[OxO964b[23]]=element[OxO964b[26]][OxO964b[30]];sel_hor[OxO964b[23]]=element[OxO964b[26]][OxO964b[31]];sel_hor_unit[OxO964b[25]]=0;if(sel_hor[OxO964b[25]]==-1){if(ParseFloatToString(element[OxO964b[26]].backgroundPositionX)){tb_hor[OxO964b[23]]=ParseFloatToString(element[OxO964b[26]].backgroundPositionX);for(var i=0;i<sel_hor_unit[OxO964b[32]][OxO964b[1]];i++){var Ox13b=sel_hor_unit[OxO964b[32]][i][OxO964b[23]];if(Ox13b&&element[OxO964b[26]][OxO964b[31]].indexOf(Ox13b)!=-1){sel_hor_unit[OxO964b[25]]=i;break ;} ;} ;} ;} ;sel_ver[OxO964b[23]]=element[OxO964b[26]][OxO964b[33]];sel_ver_unit[OxO964b[25]]=0;if(sel_ver[OxO964b[25]]==-1){if(ParseFloatToString(element[OxO964b[26]].backgroundPositionY)){tb_ver[OxO964b[23]]=ParseFloatToString(element[OxO964b[26]].backgroundPositionY);for(var i=0;i<sel_ver_unit[OxO964b[32]][OxO964b[1]];i++){var Ox13b=sel_ver_unit[OxO964b[32]][i][OxO964b[23]];if(Ox13b&&element[OxO964b[26]][OxO964b[33]].indexOf(Ox13b)!=-1){sel_ver_unit[OxO964b[25]]=i;break ;} ;} ;} ;} ;} ;SyncTo=function SyncTo_Background(element){if(tb_image[OxO964b[23]]){element[OxO964b[26]][OxO964b[27]]=OxO964b[34]+tb_image[OxO964b[23]]+OxO964b[35];} else {SetStyle(element.style,OxO964b[36],OxO964b[2]);} ;try{element[OxO964b[26]][OxO964b[28]]=inp_color[OxO964b[23]]||OxO964b[2];} catch(x){element[OxO964b[26]][OxO964b[28]]=OxO964b[2];} ;element[OxO964b[26]][OxO964b[29]]=sel_bgrepeat[OxO964b[23]]||OxO964b[2];element[OxO964b[26]][OxO964b[30]]=sel_bgattach[OxO964b[23]]||OxO964b[2];element[OxO964b[26]][OxO964b[37]]=OxO964b[2];if(sel_hor[OxO964b[25]]>0){element[OxO964b[26]][OxO964b[31]]=sel_hor[OxO964b[23]];} else {if(ParseFloatToString(tb_hor.value)){element[OxO964b[26]][OxO964b[31]]=ParseFloatToString(tb_hor.value)+sel_hor_unit[OxO964b[23]];} else {element[OxO964b[26]][OxO964b[31]]=OxO964b[2];} ;} ;if(sel_ver[OxO964b[25]]>0){element[OxO964b[26]][OxO964b[33]]=sel_ver[OxO964b[23]];} else {if(ParseFloatToString(tb_ver.value)){element[OxO964b[26]][OxO964b[33]]=ParseFloatToString(tb_ver.value)+sel_ver_unit[OxO964b[23]];} else {element[OxO964b[26]][OxO964b[33]]=OxO964b[2];} ;} ;} ;function FixTbImage(){var Ox13b=tb_image[OxO964b[23]].replace(/^(\s+)/g,OxO964b[2]).replace(/(\s+)$/g,OxO964b[2]);if(Ox13b.substr(0,4).toLowerCase()==OxO964b[34]){Ox13b=Ox13b.substr(4,Ox13b[OxO964b[1]]-4);} ;if(Ox13b.substr(Ox13b[OxO964b[1]]-1,1)==OxO964b[35]){Ox13b=Ox13b.substr(0,Ox13b[OxO964b[1]]-1);} ;if(Ox13b==OxO964b[38]){Ox13b=OxO964b[2];} ;tb_image[OxO964b[23]]=Ox13b;} ;inp_color[OxO964b[22]]=inp_color_Preview[OxO964b[22]]=function inp_color_onclick(){SelectColor(inp_color,inp_color_Preview);} ;